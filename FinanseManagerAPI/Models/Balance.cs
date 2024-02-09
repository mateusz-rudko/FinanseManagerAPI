namespace FinanseManagerAPI.Models
{
    public class Balance
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal BalanceAmount => TotalIncome - TotalExpense;
    }
}
