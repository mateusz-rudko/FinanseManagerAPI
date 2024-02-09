using FinanseManagerAPI.Data;
using FinanseManagerAPI.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FinanseManagerAPI.Interfaces
{
    public interface ITransactions
    {
        Transaction GetTransactionDetails(int transactionId);
    }
}
