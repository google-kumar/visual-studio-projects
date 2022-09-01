using System;
using System.Collections.Generic;

namespace Department_Store_Library.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public int? Quantity { get; set; }
        public string? Unit { get; set; }
    }
}
