using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exception
{
    class AgenotValidException : ApplicationException
    {
        public AgenotValidException(string message) : base(message) { }
    }

    public class voting
    {
        public int Age { get; set; }
        public void checkAge()
        {
            Console.WriteLine("enter age");
            Age = Convert.ToInt32(Console.ReadLine());
            if (Age < 18)
            {
                throw new AgenotValidException("sorry you are not eligible to vote");
            }
            else
            {
                Console.WriteLine("Thanks for Voting");

            }
        }
    }
    internal class VotingClient
    {
        static void Main()
        {
            voting votingobj = new voting();
            try
            {
                votingobj.checkAge();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }


    }
}
