using System;

namespace project_sample_1
{

    internal class Classwork_ques2
    {
        public static void main()
        {
            
            Console.WriteLine("enter your dob \n");
            DateTime dob = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("your dob : {0} \n", dob);

            DateTime today = DateTime.Now;
            Console.WriteLine("today : {0} \n", today);

            

            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            
            Console.WriteLine(" your age : " + (age/365));

            bool leap = DateTime.IsLeapYear(dob.Year);
            if (leap== true)
                Console.WriteLine("your birth year is a leap year ");
            else
                Console.WriteLine("your birth year is not a leap year ");




        }

    }
}
