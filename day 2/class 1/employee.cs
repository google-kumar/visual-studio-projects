using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_1
{
    namespace ab // to show how to use particular namespaces,it is created , see main_program_employee to have an idea on it 
    {

        internal class employee
        {

            //private member variables

            int eid;
            string ename;
            float salary;

            //public void employee()

            public employee()
            {
                eid = 123;
                ename = "hari";
                salary = 5000;
            }

            public employee(float sal)
            {
                salary = sal;
                Console.WriteLine("\n");
            }

            public employee(int eid, string ename, float salary)
            {
                this.eid = eid;
                this.ename = ename;
                this.salary = salary;
                Console.WriteLine("\n");
            }

            public employee(string ename)
            {
                this.ename = ename;
                Console.WriteLine("\n");
            }

            public void AcceptDetails()
            {
                Console.WriteLine("enter eid,ename,esalary");
                eid = Convert.ToInt32(Console.ReadLine());
                ename = Console.ReadLine();
                salary = float.Parse(Console.ReadLine());


            }
            public void displayDetails()
            {
                Console.WriteLine("your details are");
                Console.WriteLine("eid: " + eid);
                Console.WriteLine("ename: " + ename);
                Console.WriteLine("salary: " + salary);
                Console.WriteLine("\n");
            }

            ~employee()
            {
                Console.WriteLine("employee destructor called");
            }



        }
    }
    namespace abc
    {
        //we can have any num of namespace even within a namespace
    }
}
