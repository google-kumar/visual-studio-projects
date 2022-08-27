using System;

namespace project_sample_1
{
    
    internal class Classwork_ques5
    {
        
        public static void main()
        {
            void display(int n)
            {
                for (int i = 1; i <= n; i++)
                    Console.WriteLine("congratulations!!!");

            }

            Console.WriteLine("enter maximum score ");
            int n = Convert.ToInt32(Console.ReadLine());
            display(n);
            



        }

    }
}
