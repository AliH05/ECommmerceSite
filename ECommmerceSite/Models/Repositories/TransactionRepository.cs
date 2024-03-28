using ECommmerceSite.Data;
using ECommmerceSite.Models.IRepositories;
using ECommmerceSite.Services;
using System.Collections.Generic;
using System.Linq;

namespace ECommmerceSite.Models.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly CreditCardService _creditCardService;

        public TransactionRepository(ApplicationDbContext context, CreditCardService creditCardService)
        {
            _context = context;
            _creditCardService = creditCardService;
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

        public IEnumerable<CreditCard> GetCreditCardsByUserId (int userId)
        {
            var getCreditCards = _creditCardService.GetCreditCardsByUserId(userId);
            return getCreditCards;
        }
    }
}
