using FinanseManagerAPI.Data;
using FinanseManagerAPI.Interfaces;
using FinanseManagerAPI.Models;

namespace FinanseManagerAPI.Logic
{
    public class Transactions : ITransactions
    {
        private readonly DataDbContext _db;

        public Transaction GetTransactionDetails(int transactionId)
        {
            Transaction transaction = new Transaction();
            return transaction;
        }
    }
}
