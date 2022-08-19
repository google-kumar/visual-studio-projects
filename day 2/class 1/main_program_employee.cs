using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using class_1.ab;

namespace class_1
{
    internal class main_program_employee
    {
        static void Main()
        { 
            employee employee = new employee();
            //employee.AcceptDetails();
            employee.displayDetails();

            employee e1 = new employee("ram");
            e1.displayDetails();

            employee e2 = new employee(100f);
            e2.displayDetails();

            employee e3 = new employee(103,"ram",100.54f);
            e3.displayDetails();

            GC.Collect();

            // destructor printline not printed,coz before that project closed,we will see the reason later on

            
            //employee e = new employee();
            //e.AcceptDetails();
            //e.displayDetails();

        }
    }
}
