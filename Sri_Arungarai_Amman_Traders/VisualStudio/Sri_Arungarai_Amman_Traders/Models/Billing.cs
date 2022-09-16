using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sri_Arungarai_Amman_Traders.Models
{
    public partial class Billing
    {
        [Display(Name = "Serial No")]
        public int SerialNo { get; set; }

        [Display(Name = "Product Type")]
        public string ProductType { get; set; } = null!;

        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = null!;
        public double Quantity { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}