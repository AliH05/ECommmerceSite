using ECommmerceSite.Models;
using ECommmerceSite.Models.Identity;
using ECommmerceSite.Models.ViewModels;
using ECommmerceSite.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ECommmerceSite.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionService _transactionService;
        private readonly UserService _userService;
        private readonly AppUser _currentUser;

        public TransactionController(TransactionService transactionService, UserService userService)
        {
            _transactionService = transactionService;
            _userService = userService;
            _currentUser = userService.GetCurrentUser();
        }

        public IActionResult Index()
        {
            var Transactions = _transactionService.GetAllTransactions();
            return View(Transactions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var userId = _currentUser.Id;
            var transactionCreateVm = new TransactionCreateViewModel();
            transactionCreateVm.UserCards = _transactionService.GetAllCreditCardsByUser(userId).ToList();
            return View(transactionCreateVm);
        }
        [HttpPost]
        public async Task <ActionResult> Create(TransactionCreateViewModel transactionVm)
        {
            transactionVm.Transaction.Total = 10;
            var paidWithPoints = transactionVm.Transaction.PaymentType == "RewardPoints";
            if (paidWithPoints)
            {
                var validUserPoints = _userService.ValidatePointsForTransaction(transactionVm.Transaction.Total);
                if (!validUserPoints)
                {
                    return View(transactionVm);
                }

            }
            transactionVm.Transaction.UserID = _currentUser.Id;
            var createdTransaction = _transactionService.Create(transactionVm.Transaction);
            if (createdTransaction)
            {
                await UpdateUserRewardPoints(transactionVm.Transaction.Total, paidWithPoints);
                return RedirectToAction("UserTransactions");
            }
            return View();
        }

        public async Task UpdateUserRewardPoints(double transactionTotal, bool paidWithPoints = false)
        {
            if (paidWithPoints)
            {
                _currentUser.UserRewardPoints -= transactionTotal * 5;
            }
            else
            {
                var rewardPoints = _userService.CalculateUserRewardPoints(transactionTotal);
                _currentUser.UserRewardPoints += rewardPoints;
            }
            await _userService.UpdateCurrentUser();
        }

        public IActionResult UserTransactions()
        {
            var transactions = _transactionService.GetTransactionsByUserId(_currentUser.Id);
            return View(transactions);
        }
    }
}
