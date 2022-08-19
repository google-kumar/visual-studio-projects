using System;
using library_calc;

namespace calc_client
{
    internal class Program
    {
        public static Calc obj = new Calc();
        static void Main()
        {
            int result = obj.add(10, 20);
            Console.WriteLine("sum " + result);
            string msg = obj.message("vishnu");
            Console.WriteLine(msg);

        }

    }
}
