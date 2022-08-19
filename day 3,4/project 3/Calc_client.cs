using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3
{
    internal class Calc_client
    {

        public static void Main()
        {
            calc_interface c = new Casio();
            int sum = c.add(4, 5);
            Console.WriteLine("sum: "+sum);
            Console.WriteLine(c.message("casio"));

            c = new samsung();                        // same interface -  1 object to 2 classes
            int sum1 = c.add(4, 5);
            Console.WriteLine("sum: " + sum1);
            Console.WriteLine(c.message("samsung"));

            Casio c1 = new Casio();
            int sum3 = c1.add(4, 5);
            Console.WriteLine("sum: " + sum3);
            Console.WriteLine(c.message("casio 2"));
        }

    }
}
