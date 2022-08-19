using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic
{
    internal class productclient
    {

        public static void main()
        { 
           List<product> products = new List<product>();
            products.Add(new product(1,"pen",34));
            products.Add(new product(2, "pencil", 56));
           

            //github modification
            foreach (product item in products)
            { 
               Console.WriteLine(item.ToString());
            }
        }

    }
}
