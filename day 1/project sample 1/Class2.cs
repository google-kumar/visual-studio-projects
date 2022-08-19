using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_sample_1
{
    class student1
    {
        public int mathsmarks;
        public int scimarks;
    }
    internal class Class2
    {
        public static void main()
        {
            student1 Ram = new student1();
            Ram.mathsmarks = 90;
            Ram.scimarks = 100;
            student1 Raja = Ram;
            Console.WriteLine("rams maths marks" + Ram.mathsmarks);
            Console.WriteLine("rams sci marks" + Ram.scimarks);
            Console.WriteLine("rajas marks" + Raja.mathsmarks);
            Console.WriteLine("rajas marks" + Raja.scimarks);
            Ram.mathsmarks = 70;
            Ram.scimarks = 80;
            Console.WriteLine("rams maths marks" + Ram.mathsmarks);
            Console.WriteLine("rams sci marks" + Ram.scimarks);
            Console.WriteLine("rajas marks" + Raja.mathsmarks);
            Console.WriteLine("rajas marks" + Raja.scimarks);

        }

    }
}
