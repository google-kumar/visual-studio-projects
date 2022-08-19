using System;

namespace FirstConsoleApp
{
    internal class Program
    {

        static void main(string[] args)
        {

            Console.WriteLine("Hello World!");
            Console.WriteLine("enter your name ....");
            string name=Console.ReadLine();
            Console.WriteLine("hello " + name);
            Console.WriteLine("enter your marks");

            int marks = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("marks : {0}", marks);
            Console.WriteLine("enter your dob");
            DateTime dob=Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("marks : {0} , dob : {1}", marks,dob.ToShortDateString());
            Console.WriteLine("marks : {0} , dob : {1}", marks, dob);
            Console.WriteLine("enter average");
            float avg = float.Parse(Console.ReadLine());
            Console.WriteLine($"avg {avg}");
            Console.WriteLine(" enter result (true or false) ");
            bool status = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("result: ", status);


        }

    }


}