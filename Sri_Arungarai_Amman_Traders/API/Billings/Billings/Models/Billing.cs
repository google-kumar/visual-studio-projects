using System;
using System.Collections.Generic;

namespace Billings.Models
{
    public partial class Billing
    {
        public int SerialNo { get; set; }
        public string ProductType { get; set; } = null!;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public double Quantity { get; set; }
        public double Price { get; set; }
    }
}
