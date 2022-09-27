using System;
using System.Collections.Generic;

namespace Bills___Sri_Arungarai_Amman_Traders.Models
{
    public partial class Bill
    {
        public int BillNo { get; set; }
        public string? BillDate { get; set; }
        public string CustomerName { get; set; } = null!;
        public long PhoneNumber { get; set; }
        public double BillAmount { get; set; }
        public double BillPaid { get; set; }
    }
}
