using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4
{
    internal class emp
    {

        public int Eid { get; set; }
        public string Ename { get; set; }
        public emp()
        {
            Console.WriteLine("\nuser has given an empty value\n\n");
        }
        public emp(int eid, string Ename)
        { 
          Eid= eid;
            this.Ename= Ename;
        }


        public override string ToString()
        {
            return String.Format("eid: " + Eid + "********" + "ename: " + Ename);
        }
    }
}
