using FinanseManagerAPI.Data;
using FinanseManagerAPI.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FinanseManagerAPI.Interfaces
{
    public interface ITransactions
    {
        Task<Transaction> AddTransaction(Transaction transaction);
        Task<Transaction> GetTransactionDetails(int transactionId);
        Task<Transaction> DeleteTransaction(int transactionId, string userId);
        Task<Transaction> UpdateTransaction(int transactionId, Transaction transaction);
        Task<List<Transaction>> GetAllTransactions();
        
    }
}
