using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    internal class product
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public float Price { get; set; }

        public product()
        { }

        public product(int pid, string pname, float price)
        {
            Pid = pid;
            Pname = pname;
            Price = price;

        }

        public static List<product> prds = new List<product>();

        public static List<product> getAllprds()
        {
            prds.Add(new product(1, "pen", 34));
            prds.Add(new product(2, "pencil", 20));
            prds.Add(new product(3, "eraser", 10));
            return prds;
        }
        public static product getPrdByID(int id)
        { 
            //product p=(from i in prds where i.Pid == id select i).SingleOrDefault();
            product p = prds.Where(x => x.Pid == id).Select(x => x).SingleOrDefault();
            return p;
        }
        public override string ToString()
        {
            return String.Format(Pid + " " + Pname + "" + Price);
        }
        
    }
}
