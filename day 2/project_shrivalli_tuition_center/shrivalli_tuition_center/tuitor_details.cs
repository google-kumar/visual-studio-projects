using System;

namespace shrivalli_tuition_center
{
    internal class tuitor_details
    {
        //private member variables

        int Eno;
        string Tname;
        long phone_num;
        string course;
        static int count = 1;

        public void AcceptDetails()
        {
            Console.WriteLine("enter tuitor's Employee_number,Name,Phone_number,course name");
            Eno = Convert.ToInt32(Console.ReadLine());
            Tname = Console.ReadLine();
            phone_num = Convert.ToInt64(Console.ReadLine());
            course = Console.ReadLine();


        }
        public void displayDetails()
        {
            Console.WriteLine("{0} Eno: {1} Name: {2} Phone_number: {3} Course: {4} ", count++, Eno, Tname, phone_num, course);
        }

    }
}
