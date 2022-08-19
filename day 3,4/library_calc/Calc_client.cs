using System;
using library_calc;


// not an exe file, cant run it, just to know how to access the library methods it was created, to execute it find client function in same folder


namespace calc_client
{
    internal class Calc_client1
    {
        public static Calc obj=new Calc();
        static void Main()
        {
            int result = obj.add(10,20);
            Console.WriteLine("sum "+ result);
            string msg = obj.message("vishnu");
            Console.WriteLine(msg);

        }

    }
}
