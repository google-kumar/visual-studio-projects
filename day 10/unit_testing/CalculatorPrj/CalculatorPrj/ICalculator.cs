using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorPrj
{
    public interface ICalculator
    {

        int add(int a, int b);
        int sub(int a, int b);
        public bool checkAge(int age);
        public int validdata();

        string message(string name)
        {
            return "Hello " + name;
        }

    }
}
