using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic
{
    internal class product
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public float Price { get; set; }

        public product() { }

        public product (int pid, string pname, float price)
        {
            Pid = pid;
            Pname = pname;
            Price = price;
        }
        public override string ToString()
        {
            return String.Format(Pid + " " + Pname + " " + Price);
        
        }

    }
}
