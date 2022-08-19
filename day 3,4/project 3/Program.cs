using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstConsoleApp.innername;

namespace FirstConsoleApp
{
    internal class empclient
    {
        public static void main(String[] args)
        {
            Console.WriteLine("Enter no of employee: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Employee[] emp = new Employee[n];

            for (int i = 0; i < n; i++)
            {
                emp[i] = new Employee();
                emp[i].Acceptdetails();
                emp[i].PrintDetails(i + 1);
            }




        }
    }


}