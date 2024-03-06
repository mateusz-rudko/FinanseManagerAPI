using FinanseManagerAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public string UserId { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Column(TypeName = "nvarchar(24)")]
        public CategoryType Category { get; set; }
        [Required(ErrorMessage = "Payment method is required.")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Column(TypeName = "nvarchar(24)")]
        public PaymentMethod PaymentMethod { get; set; }
        [Required(ErrorMessage = "Transaction type is required.")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Column(TypeName = "nvarchar(24)")]
        public TransactionType Type { get; set; }
    }
}
