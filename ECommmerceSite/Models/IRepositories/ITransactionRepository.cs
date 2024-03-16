using System.Collections.Generic;

namespace ECommmerceSite.Models.IRepositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransactions();
        bool Create(Transaction transaction);
        Transaction GetTransactionById(int transactionId);

    }
}
