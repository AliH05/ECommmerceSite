using ECommmerceSite.Data;
using ECommmerceSite.Models.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace ECommmerceSite.Models.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Transaction transaction)
        {
            try
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            var transactions = _context.Transactions.ToList();
            return transactions;
        }

        public Transaction GetTransactionById(int transactionId)
        {
            Transaction transaction = _context.Transactions.SingleOrDefault(x => x.ID == transactionId);
            return transaction;
        }
    }
}
