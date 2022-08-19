using System;

namespace bank
{
    internal class SBAcocunt
    {
        long accountNumber;
        string accountHolderName;
        string typeofAccount;
        DateTime dateofCreation;
        int balance;

        public long AccountNumber
        {
            get { return accountNumber; }
            set
            {
                if (value > 1000000000 && value < 9999999999)
                {
                    accountNumber = value;
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

        public string TypeofAccount
        {
            get { return typeofAccount; }
            set
            {
                if (value == "CA" || value == "SB")
                {
                    typeofAccount = value;
                }
                else
                {
                    throw new ArgumentException("should be either SB or CA");
                }
            }
        }
        public string AccountHolderName
        {
            get { return accountHolderName; }
            set { accountHolderName = value; }
        }
        public DateTime DateofCreation
        {
            get { return dateofCreation; }
            set { dateofCreation = value; }
        }
        public int Balance
        {
            get { return Balance; }
            set
            {
                Balance = value;
            }
        }

        public SBAcocunt()
        {
            accountNumber = 0;
            accountHolderName = "Default";
            typeofAccount = "SB";
            dateofCreation = DateTime.MinValue;
            balance = 0;
        }
        public void GetAccountDetails()
        {
            Console.WriteLine("please enter account number (should be 10digit) ");
            accountNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("please enter account holder name ");
            accountHolderName = Console.ReadLine();
            Console.WriteLine("please enter type of account (SB or CA)");
            typeofAccount = Console.ReadLine();
            Console.WriteLine("please enter date of creation");
            dateofCreation = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("please enter the balance");
            balance = Convert.ToInt32(Console.ReadLine());
        }
        public void ShowAccountDetails()
        {
            Console.WriteLine("\tAccount number : "+accountNumber);
            Console.WriteLine("\tAccount holder name : "+accountHolderName);
            Console.WriteLine("\tType of account : "+TypeofAccount);
            Console.WriteLine("\tDate of creation : "+dateofCreation);
            Console.WriteLine("\tBalace : "+balance);
        }

    }
}
