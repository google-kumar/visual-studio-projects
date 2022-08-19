using System;

namespace project_sample_1
{

    internal class Classwork_ques3
    {
        public static void main()
        {
            int balance = 5000;

            Console.WriteLine("please enter your acc number");
            int acc = Convert.ToInt32(Console.ReadLine()); 

            Console.WriteLine("please enter 1 for withdraw 0 for deposit");
            int choice=Convert.ToInt32(Console.ReadLine());

            if (choice == 0)
            {
                Console.WriteLine("enter the amount");
                int amount = Convert.ToInt32(Console.ReadLine());
                balance = balance + amount;
            }
            else
            {
                Console.WriteLine("enter the amount");
                int amount = Convert.ToInt32(Console.ReadLine());
                balance = balance - amount;

            }

            Console.WriteLine("your acc number is : " + acc);
            Console.WriteLine("your new balance is : " + balance);
            




        }

    }
}
