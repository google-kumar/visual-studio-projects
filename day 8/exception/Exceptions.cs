using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exception
{
    internal class Exceptions
    {
        public static void main()
        {
            int c = 0;
            try
            {
                Console.WriteLine("enter 2 numbers");
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                c = a / b;
                int[] arr = new int[2] { 5, 6 };
                Console.WriteLine(arr[5]);
            }
            catch (FormatException)
            {
                Console.WriteLine("please enter only numbers");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("second number cannot be zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(c);
            }
            
            
            
        }

    }
}
