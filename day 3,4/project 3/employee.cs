using System;
namespace FirstConsoleApp
{
    namespace innername
    {
        internal class Employee
        {
            int eid;
            string ename;
            float salary;
            static int count = 1;

            public Employee()
            {
                eid = 404;
                ename = "xxx";
                salary = 5000;
            }
            public Employee(float salary)
            {
                this.salary = salary;
            }
            public Employee(int eid)
            {
                this.eid = eid;
            }
            public Employee(int eid, string ename, float salary) : this(eid)
            {
                this.ename = ename;
                this.salary = salary;
            }

            public void Acceptdetails()
            {
                Console.WriteLine("Enter eid, ename, salary of emplyee " + count + ": ");
                eid = Convert.ToInt32(Console.ReadLine());
                ename = Console.ReadLine();
                salary = float.Parse(Console.ReadLine());
                calculate(salary);
                count++;
            }
            public static void calculate(float sal)
            {
                Employee emp = new Employee();
                Console.WriteLine("==");
                Console.WriteLine(emp.salary);
                Console.WriteLine("==");

                for (int i = 0; i < count; i++)
                {
                    if (sal > 1000)
                    {
                        Console.WriteLine("Bonus of 10000");
                    }
                }
            }
            ~Employee()
            {
                Console.WriteLine("end of program");

            }
            public void PrintDetails(int i)
            {
                Console.WriteLine("Details of employee " + i + " is: ");
                Console.WriteLine(eid);
                Console.WriteLine(ename);
                Console.WriteLine(salary);
                
            }
        }
    }

}