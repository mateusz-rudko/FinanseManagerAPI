using FinanseManagerAPI.Data;
using FinanseManagerAPI.Interfaces;
using FinanseManagerAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FinanseManagerAPI.Logic
{
    public class Transactions : ITransactions
    {
        private readonly DataDbContext _db;

        public Transactions(DataDbContext db)
        {
            _db = db;
        }
        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            if(transaction != null)
            {
                _db.Transactions.Add(transaction);
                await _db.SaveChangesAsync();
                return transaction;
            }
            throw new ArgumentNullException(nameof(transaction), "Transaction cannot be empty");

        }
        public async Task<Transaction> GetTransactionDetails(int transactionId)
        {
            Transaction transaction = new Transaction();
            return transaction;
        }
    }
}
