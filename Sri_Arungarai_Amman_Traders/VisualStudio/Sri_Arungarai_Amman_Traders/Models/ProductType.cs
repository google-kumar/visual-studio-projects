using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;


namespace Sri_Arungarai_Amman_Traders.Models
{
    public partial class ProductTypes
    {
        [Display(Name = "Product Type Id")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Product Type Name")]
        public string ProductTypeName { get; set; } = null!;
    }
}
