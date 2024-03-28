using ECommmerceSite.Models;
using ECommmerceSite.Models.IRepositories;
using ECommmerceSite.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECommmerceSite.Services
{
    public class CreditCardService
    {
        private readonly CreditCardRepository _creditCardRepository;

        public CreditCardService(CreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }
        public bool Create(CreditCard creditCard)
        {
            var createCard = _creditCardRepository.Create(creditCard);
            return createCard;
        }

        public bool Delete(int creditCardId)
        {
            var deleteCard =  _creditCardRepository.Delete(creditCardId);
            return deleteCard;

        }

        public IEnumerable<CreditCard> GetAllCreditCards()
        {
            var getAll = _creditCardRepository.GetAllCreditCards();
            return getAll;
        }

        public CreditCard GetCreditCardById(int creditCardId)
        {
            var gettingCreditCardById = _creditCardRepository.GetCreditCardById(creditCardId);
            return gettingCreditCardById;
        }

        public bool Update(CreditCard creditCard)
        {
           var updateCard = _creditCardRepository.Update(creditCard);
            return updateCard;
        }

        public IEnumerable<CreditCard> GetCreditCardsByUserId(int userId)
        {
            var creditCardsbyId = _creditCardRepository.GetAllCreditCards().Where(x => x.UserID == userId);
            return creditCardsbyId.ToList();
        }
    }
}
