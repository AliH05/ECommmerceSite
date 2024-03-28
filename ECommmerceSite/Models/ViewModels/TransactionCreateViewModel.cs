using System.Collections.Generic;

namespace ECommmerceSite.Models.ViewModels
{
    public class TransactionCreateViewModel
    {
        public Transaction Transaction { get; set; }
        public List<CreditCard> UserCards { get; set; }
        public int ChosenCardId { get; set; }
    }
}
