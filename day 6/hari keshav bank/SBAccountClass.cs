using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAccount
{
    internal class SBAccountClass
    {
        long AccountNumber;
        string AccountHolderName;
        string TypeOfAccount;
        DateOnly DateofCreation;
        long Balance;
        public SBAccountClass()
        {
            AccountNumber = 1234567890;
            AccountHolderName = "Hari Kheshav";
            TypeOfAccount = "OD";
            DateofCreation = new DateOnly(2022, 06, 22);
            Balance = 100000;
        }
        public SBAccountClass(long accountNumber, string accountHolderName, string typeOfAccount)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            TypeOfAccount = typeOfAccount;
        }
        public SBAccountClass(long accountNumber, string accountHolderName, string typeOfAccount, DateOnly dateofCreation, long balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            TypeOfAccount = typeOfAccount;
            DateofCreation = dateofCreation;
            Balance = balance;
        }
        public void GetAccountDetails()
        {
            Console.WriteLine("Enter Account Number, Account Holder Name, Type Of Account, Date Of Creation and Balance");
            AccountNumber = Convert.ToInt32(Console.ReadLine());
            AccountHolderName = Console.ReadLine();
            TypeOfAccount = Console.ReadLine();
            DateofCreation = DateOnly.Parse(Console.ReadLine());
            Balance = Convert.ToInt32(Console.ReadLine());
        }
        public long Acno
        {
            get { return AccountNumber; }
            set { 
                if(value<0) 
                    AccountNumber = -value; 
                else
                    AccountNumber = value;
                }
        }
        public string Acname
        {
            get { return AccountHolderName; }
            set { AccountHolderName = value; }

        }
        public string ACType
        {
            get { return ACType; }
            set { TypeOfAccount = value;  }
        }
        public DateOnly doc
        {
            get { return DateofCreation; }
            set { DateofCreation = value; }
        }
        public long Bal
        {
            get { return Balance; }
            set { Balance = value; }
        }
        public void ShowAccountDetails()
        {
            Console.WriteLine("Account Number:"+ AccountNumber);
            Console.WriteLine("Account Holder Name:"+AccountHolderName);
            Console.WriteLine("Type Of Account:"+ TypeOfAccount);
            Console.WriteLine("DateofCreation:"+ DateofCreation);
            Console.WriteLine("Balance:"+Balance);
        }
    } 
}
