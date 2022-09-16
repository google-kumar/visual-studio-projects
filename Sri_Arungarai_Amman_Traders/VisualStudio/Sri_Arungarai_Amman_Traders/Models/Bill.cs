using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Sri_Arungarai_Amman_Traders.Models
{
    public partial class Bill
    {


        public Bill()
        {
            BillDate = DateTime.Today.ToShortDateString();
        }

        [Display(Name = "Bill No")]
        public int BillNo { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public string? BillDate { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = null!;

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Range(5555555555, 9999999999)]
        public long PhoneNumber { get; set; }

        [Display(Name = "Bill Amount")]
        [DataType(DataType.Currency)]
        public double BillAmount { get; set; }

        [Display(Name = "Bill Paid")]
        [DataType(DataType.Currency)]
        public double BillPaid { get; set; }
    }
}
