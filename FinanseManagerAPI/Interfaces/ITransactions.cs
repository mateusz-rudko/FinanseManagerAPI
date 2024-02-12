using FinanseManagerAPI.Data;
using FinanseManagerAPI.Models;
using FinanseManagerAPI.Models.Enums;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FinanseManagerAPI.Interfaces
{
    public interface ITransactions
    {
        Task<Transaction> GetTransactionDetails(int transactionId, string userId);
        Task<Transaction> AddTransaction(Transaction transaction);   
        Task<Transaction> DeleteTransaction(int transactionId, string userId);
        Task<Transaction> UpdateTransaction(int transactionId, Transaction transaction);
        Task<List<Transaction>> GetTransactionsByTimeRange(string userId, DateTime startDate, DateTime? endDate);
        Task<Dictionary<CategoryType, Dictionary<TransactionType, decimal>>> CalculateExpensesAndIncomesByCategory(string userId, DateTime startDate, DateTime? endDate);
    }
}
