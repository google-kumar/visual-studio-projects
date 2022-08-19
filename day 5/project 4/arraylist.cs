using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace project_4
{
    internal class arraylist
    {

        public static void main()
        {
            int[] a = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("enter {0} th element ",i+1);
                a[i]=Convert.ToInt32(Console.ReadLine());
            }
            int[] a1 = new int[] { 2,3,4,5};
            Console.WriteLine("elements are: ");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" {0} th element : {1} ",i+1, a[i]);
            }

            ArrayList al=new ArrayList();
            al.Add(4);
            al.Add("ram");

            Console.WriteLine("elements are: ");
            foreach (var item in al)
            {
                
                Console.WriteLine(item);
            }

            al.Remove(4);
            Console.WriteLine("count: "+al.Count);
            foreach (var item in al)
            {
                Console.WriteLine(item);
            }

        }

    }
}
