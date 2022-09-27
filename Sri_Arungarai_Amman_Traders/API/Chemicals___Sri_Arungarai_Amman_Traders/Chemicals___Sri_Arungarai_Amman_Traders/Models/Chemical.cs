using System;
using System.Collections.Generic;

namespace Chemicals___Sri_Arungarai_Amman_Traders.Models
{
    public partial class Chemical
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public double QuantityAvailable { get; set; }
        public string ProductUnit { get; set; } = null!;
        public double Price { get; set; }
        public string? PurchaseDate { get; set; }
    }
}
