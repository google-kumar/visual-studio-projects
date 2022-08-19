using System;

namespace bank
{
    internal class client
    {

        public static void Main()
        {
            int n = 4;
            SBAcocunt[] s = new SBAcocunt[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("client no : "+(i+1));
                s[i] = new SBAcocunt();
                s[i].GetAccountDetails();
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("client no : " + (i + 1));
                s[i].ShowAccountDetails();
            }


            SBTransaction[] t = new SBTransaction[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("transaction no : " + (i + 1));
                t[i] = new SBTransaction();
                t[i].GetTransactionDetails();
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("transaction no : " + (i + 1));
                t[i].ShowTransactionDetails();
            }
        }

    }
}
