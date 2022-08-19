using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3
{
    internal class product
    {
        int pid;
        string pname;
        public int price;
        public int Pid
        { 
           get { return pid; }  

            set { 
                   if(value>0)
                     pid = value;
                   else 
                      pid = 0;
                }
        }
        public string Pname { get; set; }
        public int Qty { get; }

        public product()
        {
            Qty = 10;
        }

    }
    class productclient
    {
        public static void main()
        { 
          product p = new product();
            p.Pid = 700;
           // p.Qty = 900; // read only
            Console.WriteLine(p.Pid);
            Console.WriteLine("enter the product name");
            p.Pname = Console.ReadLine();
            p.price = -900;
            Console.WriteLine(p.price);

        
        }
    
    }

}
