using FinanseManagerAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FinanseManagerAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 0,ErrorMessage = "Description should have maximum 30 letters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Transaction amount is required.")]
        public decimal Amount {  get; set; }
        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public CategoryType Category { get; set; }
        [Required(ErrorMessage = "Payment method is required.")]
        public PaymentMethod PaymentMethod { get; set; }
        [Required(ErrorMessage = "Transaction type is required.")]
        public TransactionType Type { get; set; }
    }
}
