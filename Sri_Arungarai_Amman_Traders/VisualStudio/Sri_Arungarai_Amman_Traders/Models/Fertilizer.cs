using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sri_Arungarai_Amman_Traders.Models
{
    public partial class Fertilizer
    {


        public Fertilizer()
        {
            PurchaseDate = DateTime.Today.ToShortDateString();
        }

        [Display(Name = "Id")]
        public int ProductId { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; } = null!;

        [Display(Name = "Quantity Available")]
        public double QuantityAvailable { get; set; }

        [Display(Name = "Unit")]
        public string ProductUnit { get; set; } = "Kg";

        [Display(Name = "Price per Kg")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]



        public string? PurchaseDate { get; set; }
    }
}
