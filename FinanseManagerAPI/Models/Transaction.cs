using FinanseManagerAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FinanseManagerAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }  
        public string Description { get; set; }
        public decimal Amount {  get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public CategoryType Category { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public TransactionType Type { get; set; }
    }
}
