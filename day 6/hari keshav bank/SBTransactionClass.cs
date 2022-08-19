using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAccount
{
    internal class SBTransactionClass
    {
        int TransactionID;
        long TAccountNumber;
        DateOnly TransactionDate;
        long TransactionAmt;
        long NewBalance;
        public SBTransactionClass()
        {
            TransactionID = 1;
            TAccountNumber = 1234567890;
            TransactionDate = new DateOnly(2022, 06, 22);
            TransactionAmt = 500;
            NewBalance = 100000;
        }
        public SBTransactionClass(int transid, long tacno, long tamt)
        {
            TransactionID = transid;
            TAccountNumber = tacno;
            TransactionAmt = tamt;
        }
        public SBTransactionClass(int transid, long tacno, long tamt, DateOnly transdt, long nbal)
        {
            TransactionID = transid;
            TAccountNumber = tacno;
            TransactionAmt = tamt;
            TransactionDate = transdt;
            NewBalance = nbal;
        }
        public void GetTransactionDetails()
        {
            Console.WriteLine("Enter Transaction Id,Transaction Account Number, Transaction Amount,Transaction Date and New Balance");
            TransactionID = Convert.ToInt32(Console.ReadLine());
            TAccountNumber = Convert.ToInt32(Console.ReadLine());
            TransactionAmt = Convert.ToInt32(Console.ReadLine());
            TransactionDate = DateOnly.Parse(Console.ReadLine());
            NewBalance = Convert.ToInt32(Console.ReadLine());
        }
        public int TId
        {
            get { return TransactionID; }
            set { 
                if(value<0)
                    TransactionID = -value; 
                else
                    TransactionID = value;
                }
        }
        public long Tno
        {
            get { return TAccountNumber; }
            set
            {
                if (value < 0)
                    TAccountNumber = -value;
                else
                    TAccountNumber = value;
            }
        }
        public long Tamt
        {
            get { return TransactionAmt; }
            set
            {
                if (value < 0)
                    TransactionAmt = -value;
                else
                    TransactionAmt = value;
            }
        }
        public DateOnly tdate
        {
            get { return TransactionDate; }
            set { TransactionDate = value; }
        }
        public long Nbal
        {
            get { return NewBalance; }
            set { NewBalance = value; }
        }
        public void ShowTransactionDetails()
        {
            Console.WriteLine("Transaction ID:" + TransactionID);
            Console.WriteLine("TAccount Number:" + TAccountNumber);
            Console.WriteLine("Transaction Amount:" + TransactionAmt);
            Console.WriteLine("Transaction Date:" + TransactionDate);
            Console.WriteLine("New Balance:" + NewBalance);
        }
    } 
}
