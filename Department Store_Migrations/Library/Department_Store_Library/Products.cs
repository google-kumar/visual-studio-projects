using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Department_Store_Library
{
    public class Products
    {
        [Key]

        public int Product_Id { get; set; }
        [Required]
        public string Product_Name { get; set; }
        public float Product_Price { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

    }
}