using System.Collections.Generic;

namespace ECommmerceSite.Models.IRepositories
{
    public interface ICreditCardRepository
    {
        bool Create(CreditCard creditCard);

        bool Update(CreditCard creditCard);

        bool Delete(int creditCardId);

        CreditCard GetCreditCardById(int creditCardId);

        IEnumerable<CreditCard> GetAllCreditCards();
    }
}
