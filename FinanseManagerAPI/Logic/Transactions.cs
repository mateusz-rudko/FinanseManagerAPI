using FinanseManagerAPI.Data;
using FinanseManagerAPI.Interfaces;
using FinanseManagerAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FinanseManagerAPI.Logic
{
    public class Transactions : ITransactions
    {
        private readonly DataDbContext _db;

        public Transactions(DataDbContext db)
        {
            _db = db;
        }
        public async Task<Transaction> GetTransactionDetails(int transactionId, string userId)
        {
            try
            {
                var transaction = await _db.Transactions.FirstOrDefaultAsync(t => t.Id == transactionId && t.UserId == userId);
                if(transaction != null)
                {
                    return transaction;
                }
                throw new ArgumentException("Transaction not found", nameof(transactionId));
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while getting the transaction", ex);
            }
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
        public async Task<Transaction> DeleteTransaction(int transactionId, string userId)
        {
            try
            {
                var transaction = await GetTransactionDetails(transactionId, userId);
                if(transaction != null)
                {
                    _db.Transactions.Remove(transaction);
                    await _db.SaveChangesAsync();
                    return transaction;
                }
                throw new ArgumentException("Transaction not found", nameof(transactionId));
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while deleting the transaction", ex);
            }
        }

        public Task<List<Transaction>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        

        public Task<Transaction> UpdateTransaction(int transactionId, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
