namespace SecondApp
{
    internal class Employee
    {
        //private member variables
        int eid;
        string ename;
        float salary;
        static int accept_count = 1;
        static int disp_count = 1;
        public Employee()
        {
            eid = 123;
            ename = "abc";
            salary = 10000;
        }
        public Employee(int eid, string ename, float salary)
        {
            this.eid = eid;
            this.ename = ename;
            this.salary = salary;
        }
        public Employee(string ename)
        {
            this.ename = ename;
        }
        public Employee(float sal)
        {
            salary = sal;
        }
        public Employee(int eid)
        {
            this.eid = eid;
        }
        public int Eid
        {
            get { return eid; }
            set { 
                if(value> 0) 
                    eid = value; 
                else
                    eid = 0;
                }
        }
        public string Ename
        {
            get { return ename; }
        }
        public void AcceptDetails()
        {
            Console.WriteLine("Employee:" + accept_count);
            Console.WriteLine("Enter Eid,Ename, Salary");
            eid = Convert.ToInt32(Console.ReadLine());
            ename = Console.ReadLine();
            salary = float.Parse(Console.ReadLine());
            accept_count += 1;
        }
        public void EmployeeDisplay()
        {
            Console.WriteLine("Employee:" + disp_count);
            Console.WriteLine("Employee Id:"+ eid);
            Console.WriteLine("Employee Name:"+ ename);
            Console.WriteLine("Employee Salary:"+ salary);
            disp_count += 1;
        }
     ~Employee()
        {
            Console.WriteLine("Employee Destroyed");
        }
    }

}