using System;

namespace BankLibrary
{
    public class SBAccount 
    {
        long AccountNumber;
        string CustomerName;
        string CustomerAddress;
        decimal CurrentBalance;
        

        public SBAccount() { }

        public SBAccount(long accountnumber, string customername,string customeraddress,decimal currentbalance)
        {
            AccountNumber=accountnumber;
            CustomerAddress=customeraddress;
            CurrentBalance=currentbalance;
            CustomerName=customername;
            
        }
        public override string ToString()
        {
            return String.Format("\tAccount Number: " + AccountNumber + "\n\tCustomer Name: " + CustomerName + "\n\tCustomer Address: " + CustomerAddress + "\n\tCurrent Balance: " + CurrentBalance);

        }


        public string customername{ get { return CustomerName; } set { CustomerName = value; } }
        public string customeraddress{ get { return CustomerAddress; } set { CustomerAddress = value; } }
        public long accountnumber
        {
            get
            {
                return AccountNumber;
            }
            set
            {
                if (value > 1000000000 && value < 9999999999)
                {
                    AccountNumber = value;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Account number should be 10 digit, please enter a valid number");
                        value = Convert.ToInt64(Console.ReadLine());
                    } while (value < 1000000000 || value > 9999999999);
                    AccountNumber = value;
                }

            }
        }
        public decimal currentbalance
        {
            get { return CurrentBalance; }
            set
            {
                if (value < 0)
                {
                    CurrentBalance = 0;
                }
                else
                {
                    CurrentBalance = value;
                }
            }
        
        }
    }
    public class SBTransaction 
    {
        string TransactionID;
        DateTime TransactionDate;
        long AccountNumber;
        decimal Amount;
        string TransactionType;

        public SBTransaction() { }

        public SBTransaction(string transactionid, DateTime transactiondate, long accountnumber, decimal amount,string transactiontype)
        {
            AccountNumber = accountnumber;
            TransactionDate = transactiondate;
            TransactionID = transactionid;
            Amount = amount;
            TransactionType = transactiontype;
        }
        public override string ToString()
        {
            return String.Format("\tTransaction ID: " + TransactionID + "\n\tTransaction Date: " + TransactionDate.ToShortDateString() + "\n\tAccountNumber: " + AccountNumber + "\n\tAmount: " + Amount + "\n\tTransaction Type: " + TransactionType );

        }

        public string transactionid { get { return TransactionID; } set { TransactionID = value; } }
        public string transactiontype { get { return TransactionType; } set { TransactionType = value; } }
        public DateTime transactiondate { get { return TransactionDate; }set { TransactionDate = value; } }
        public long accountnumber
        {
            get
            {
                return AccountNumber;
            }
            set
            {
                if (value > 1000000000 && value < 9999999999)
                {
                    AccountNumber = value;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Account number should be 10 digit, please enter a valid number");
                        value = Convert.ToInt64(Console.ReadLine());
                    } while (value < 1000000000 || value > 9999999999);
                    AccountNumber = value;
                }

            }
        }
        public decimal amount
        {
            get { return Amount; }
            set
            {
                if (value < 0)
                {
                    Amount = 0;
                }
                else
                {
                    Amount = value;
                }
            }

        }
    }
    public interface IBankRepositary
    {
        void NewAccount(SBAccount acc);
        SBAccount GetAccountDetails(long accno);
        List<SBAccount> GetAllAccounts();
        void DepositAmount(long accno, decimal amt);
        void WithdrawAmount(long accno, decimal amt);
        List<SBTransaction> GetTransactions(long accno);

    }
}