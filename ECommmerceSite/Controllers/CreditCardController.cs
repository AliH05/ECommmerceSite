using ECommmerceSite.Models;
using ECommmerceSite.Models.Identity;
using ECommmerceSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace ECommmerceSite.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly CreditCardService _creditCardService;
        private readonly UserService _userService;
        private readonly AppUser _currentUser;
        public CreditCardController(CreditCardService creditCardService, UserService userService)
        {
            _creditCardService = creditCardService;
            _userService = userService;
            _currentUser = _userService.GetCurrentUser();
        }
        public IActionResult UserCreditCards()
        {
            var userId = _currentUser.Id;
            var getCreditCardsbyUserId = _creditCardService.GetCreditCardsByUserId(userId);
            return View(getCreditCardsbyUserId);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreditCard creditCard)
        {
            creditCard.UserID = _currentUser.Id;
            var createdCard = _creditCardService.Create(creditCard);
            if (createdCard)
            {
                return RedirectToAction("UserCreditCards");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int creditCardId)
        {
            var creditCard = _creditCardService.GetCreditCardById(creditCardId);
            return View(creditCard);
        }

        [HttpPost]
        public IActionResult Update(CreditCard creditCard)
        {
            var updatedCard = _creditCardService.Update(creditCard);
            if(updatedCard)
            {
                return RedirectToAction("UserCreditCards");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var deleteCard = _creditCardService.Delete(id);
            return RedirectToAction("UserCreditCards");
        }
    }
}
