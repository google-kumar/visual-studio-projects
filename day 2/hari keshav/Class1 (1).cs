using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondApp
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            Employee E1 = new Employee();
            Employee E2 = new Employee("Hari");   
            Employee E3 = new Employee(1230.33f);
            Employee E4 = new Employee(1234);
            Employee E5 = new Employee(1234,"Hari",1230.34f);
            //E.AcceptDetails();
            //E1.EmployeeDisplay();
            //E2.EmployeeDisplay();
            //E3.EmployeeDisplay();
            //E4.EmployeeDisplay();
            //Console.WriteLine("No Of Employees:");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Employee[] E6 = new Employee[n];
            //for (int i = 0; i < n; i++)
            //{
            //    E6[i] = new Employee();
            //    E6[i].AcceptDetails();
            //}
            //for (int i = 0; i < n; i++)
            //{
            //    E6[i].EmployeeDisplay();
            //}
            Employee E7 = new Employee();
            E7.Eid = 12;//set routine
            Console.WriteLine(E7.Eid);//get routine
            Employee E8 = new Employee();
            E8.Eid = -12;
            Console.WriteLine(E8.Eid);
            //E8.Ename = "xyz";
            //We see that the above line gives errors if uncommented, because there is no set attribute in the class, so it cannot be set and is thus, readonly.
            //Also, note that the default Ename can be displayed without any errors as shown below.
            Console.WriteLine(E8.Ename);
        }
    }
}
