﻿using FinanseManagerAPI.Models.Enums;

namespace FinanseManagerAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal Amount {  get; set; }
        public DateTime Date { get; set; }
        public CategoryType Category { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public TransactionType Type { get; set; }
    }
}