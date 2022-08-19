using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shrivalli_tuition_center
{
    internal class salary_detail
    {

        int Eno;
        string Tname;
        int salary;

        static int count = 1;

        public void AcceptDetails()
        {

            Console.WriteLine("enter tuitor's Employee_number,Tuitor_name,salary");
            Eno = Convert.ToInt32(Console.ReadLine());
            Tname = Console.ReadLine();
            salary = Convert.ToInt32(Console.ReadLine());

        }
        public void displayDetails()
        {

            Console.WriteLine("{0} Eno: {1} Name: {2} salary: {3} ", count++, Eno, Tname, salary);
        }

    }
}
