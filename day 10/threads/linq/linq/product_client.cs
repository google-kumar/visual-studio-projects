using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    internal class product_client
    {
        public static List<product> products = product.getAllprds();
        public static void DisplayProducts()
        {
            foreach (var item in products)
            { 
               Console.WriteLine(item.ToString());
            }
        }

        public static void DisplayPartPrd()
        {
            Console.WriteLine("enter the product ID");
            int id = Convert.ToInt32(Console.ReadLine());
            product p=product.getPrdByID(id);
            Console.WriteLine(p.ToString());
        }

        public static void Main()
        {
            DisplayProducts();
            DisplayPartPrd();
        }
    }

}
