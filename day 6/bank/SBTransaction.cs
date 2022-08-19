using System;

namespace bank
{
    internal class SBTransaction
    {
        string transactionID;
        long tAccountNumber;
        int transactionAmount;
        DateTime transactionDate;
        int newBalance;

        public long TAccountNumber
        {
            get { return tAccountNumber; }
            set
            {
                if (value > 1000000000 && value < 9999999999)
                {
                    tAccountNumber = value;
                }
                else
                {
                    //value = 0;
                    do
                    {
                        Console.WriteLine("Account number should be 10 digits");
                        value = Convert.ToInt64(Console.ReadLine());

                    } while (value < 1000000000 && value > 9999999999);

                }
            }
        }

        public string TransactionID
        {
            get { return transactionID; }
            set { transactionID = value; }
        }
        public int TransactionAmount
        {
            get { return transactionAmount; }
            set { transactionAmount = value; }
        }
        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set { transactionDate = value; }
        }
        

        public SBTransaction()
        {
            tAccountNumber = 0;
            transactionID = "00-default-00";
            transactionAmount = 0;
            transactionDate = DateTime.MinValue;
            newBalance = 0;
        }
        public void GetTransactionDetails()
        {
            Console.WriteLine("please enter account number (should be 10digit) ");
            tAccountNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("please enter transaction ID ");
            transactionID= Console.ReadLine();
            Console.WriteLine("please enter the transaction amount");
            transactionAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter transaction date");
            transactionDate = Convert.ToDateTime(Console.ReadLine());
            newBalance = newBalance - transactionAmount;
        }
        public void ShowTransactionDetails()
        {
            Console.WriteLine("\tTransaction Account number : " + tAccountNumber);
            Console.WriteLine("\tTransaction ID : " + transactionID);
            Console.WriteLine("\tTransaction amount : " + transactionAmount);
            Console.WriteLine("\tTransaction date : " + transactionDate);
            Console.WriteLine("\tNew balance : " + newBalance);
        }

    }
}
