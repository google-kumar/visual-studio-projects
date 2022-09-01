using System;
using System.Collections.Generic;

namespace EntityFramework_example.Models
{
    public partial class Sbtransaction
    {
        public string? TransactionId { get; set; }
        public string? TransactionDate { get; set; }
        public long? AccountNumber { get; set; }
        public decimal? Amount { get; set; }
        public string? TransactionType { get; set; }
    }
}
