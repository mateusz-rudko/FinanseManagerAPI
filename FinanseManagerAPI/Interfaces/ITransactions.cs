using FinanseManagerAPI.Data;
using FinanseManagerAPI.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FinanseManagerAPI.Interfaces
{
    public interface ITransactions
    {
        Task<Transaction> AddTransaction(Transaction transaction);
        Task<Transaction> GetTransactionDetails(int transactionId);
    }
}
