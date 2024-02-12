using FinanseManagerAPI.Data;
using FinanseManagerAPI.Interfaces;
using FinanseManagerAPI.Models;
using FinanseManagerAPI.Models.Enums;
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
            catch(Exception ex)
            {
                throw new Exception("An error occurred while deleting the transaction", ex);
            }
        }
        public async Task<List<Transaction>> GetTransactionsByTimeRange(string userId, DateTime startDate, DateTime? endDate)
        {
            try
            {
                var transactions = await _db.Transactions
                    .Where(x => x.UserId == userId && x.Date >= startDate && (endDate == null ? x.Date <= DateTime.Now : x.Date <= endDate))
                    .ToListAsync();
                return transactions.Count > 0 ? transactions : throw new ArgumentException("Empty list of transactions");
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while getting the transactions", ex);
            }
        }
        public async Task<Dictionary<CategoryType, Dictionary<TransactionType, decimal>>> CalculateExpensesAndIncomesByCategory(string userId, DateTime startDate, DateTime? endDate)
        {
            var transactions = await GetTransactionsByTimeRange(userId, startDate, endDate);
            var groupedTransactions = transactions.GroupBy(t => t.Category)
                                                  .ToDictionary(
                                                   g => g.Key,
                                                   g => g.GroupBy(t => t.Type)
                                                         .ToDictionary(
                                                           t => t.Key,
                                                           t => t.Sum(a => a.Amount)));
            return groupedTransactions;
        }
        public Task<Transaction> UpdateTransaction(int transactionId, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
