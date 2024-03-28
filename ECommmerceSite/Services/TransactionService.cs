using ECommmerceSite.Models;
using ECommmerceSite.Models.IRepositories;
using ECommmerceSite.Models.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECommmerceSite.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _transactionRepository;

        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public bool Create(Transaction transaction)
        {
            bool createdTransaction = _transactionRepository.Create(transaction);
            return createdTransaction;
        }
        public IEnumerable<Transaction> GetAllTransactions()
        {
            var gottenTransactions = _transactionRepository.GetAllTransactions();
            return gottenTransactions;
        }

        public Transaction GetTransactionById(int transactionId)
        {
            var transactionById = _transactionRepository.GetTransactionById(transactionId);
            return transactionById;
        }

        public IEnumerable<Transaction> GetTransactionsByUserId(int userId) 
        {
            var transactions = _transactionRepository.GetAllTransactions().Where(x => x.UserID == userId);
            return transactions;
        }

        public IEnumerable<CreditCard> GetAllCreditCardsByUser(int userId)
        {
            var getCreditCards = _transactionRepository.GetCreditCardsByUserId(userId);
            return getCreditCards;
        }
    }
}
