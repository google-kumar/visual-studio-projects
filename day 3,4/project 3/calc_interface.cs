using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3
{
    internal interface calc_interface
    {

        int add(int x, int y);
        int sub(int x, int y);

        int mul(int x, int y);

        int div(int x, int y);

        string message (string companyname)
        { 
            return "hi  "+companyname;
        
        }

    }
}
