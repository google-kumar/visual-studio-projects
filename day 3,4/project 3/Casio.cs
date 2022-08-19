using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3
{
    internal class Casio : calc_interface
    {
        public int add(int x, int y)
        {
            
            return x + y;
        }

        public int div(int x, int y)
        {
            return x/y;
        }

        public int mul(int x, int y)
        {
            return x * y;

        }
        public int sub(int x, int y)
        {
            return x - y;
        }
    }
}
