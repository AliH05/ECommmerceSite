using ECommmerceSite.Data;
using ECommmerceSite.Models.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace ECommmerceSite.Models.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly ApplicationDbContext _context;

        public CreditCardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(CreditCard creditCard)
        {
            try
            {
                _context.CreditCards.Add(creditCard);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Delete(int creditCardId)
        {
            try
            {
                var currentCard = GetCreditCardById(creditCardId);
                _context.CreditCards.Remove(currentCard);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<CreditCard> GetAllCreditCards()
        {
            var gettingCreditCards = _context.CreditCards.ToList();
            return gettingCreditCards;
        }

        public CreditCard GetCreditCardById(int creditCardId)
        {
            var gettingCreditByUserId = _context.CreditCards.SingleOrDefault(x => x.ID == creditCardId);
            return gettingCreditByUserId;
        }

        public bool Update(CreditCard creditCard)
        {
            try
            {
                _context.CreditCards.Update(creditCard);
                _context.SaveChanges();
                return true;

            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
