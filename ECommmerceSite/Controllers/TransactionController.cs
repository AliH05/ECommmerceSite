using ECommmerceSite.Models;
using ECommmerceSite.Models.Identity;
using ECommmerceSite.Services;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            transaction.UserID = _currentUser.Id;
            var createdTransaction = _transactionService.Create(transaction);
            if (createdTransaction)
            {
                return RedirectToAction("UserTransactions");
            }
            return View();
        }

        public IActionResult UserTransactions()
        {
            var transactions = _transactionService.GetTransactionsByUserId(_currentUser.Id);
            return View(transactions);
        }
    }
}
