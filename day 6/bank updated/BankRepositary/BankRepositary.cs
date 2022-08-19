using System;
using System.Collections.Generic;
using BankLibrary;



namespace BankRepositary
{
    public class BankRepositary : IBankRepositary
    {
        List<SBAccount> SBAccounts = new List<SBAccount>();
        List<SBTransaction> SBTransactions = new List<SBTransaction>();
        static int Count1 = 1;
        static int Count2 = 1;
        long accountnumber_generation=1000000000;
        static int sbacc_creation = 0;

        public void DepositAmount(long accno, decimal amt)
        {
            int flag = 0;
            foreach (SBAccount item in SBAccounts)
            {
                if (item.accountnumber == accno)
                { 
                    item.currentbalance =item.currentbalance + amt;
                    string T_id = "SBI_Deposit_" + Count1++;
                    DateTime T_date = DateTime.Today;
                    string T_type = "Deposit";

                    SBTransactions.Add(new SBTransaction(T_id, T_date, accno, amt, T_type));
                    flag = 1;
                }
            }
            if (flag == 0)
                Console.WriteLine("Account not Found");
        }

        public SBAccount GetAccountDetails(long accno)
        {
            int Flag = 0;
            foreach (SBAccount item in SBAccounts)
            {
                if (item.accountnumber == accno)
                {
                    Flag = 1;
                    Console.WriteLine(item.ToString());
                    return null;
                }
            }
            if (Flag == 0)
            {
                //throw new Exception("Account not found ");
                Console.WriteLine(" Account not found ");
                return null;
            }
            throw new Exception(" ");

        }

        public List<SBAccount> GetAllAccounts()
        {
            
            
            if (sbacc_creation == 0)
            {
                Console.WriteLine(" No Accounts found ");
                return null;
            }

            if (SBAccounts != null)
            {
                
                return SBAccounts;
            }
            
            
            return null;
            
        }

        public List<SBTransaction> GetTransactions(long accno)
        {
            int flag = 0;
            List<SBTransaction> SBTransactions_temp = new List<SBTransaction>();

            if (SBTransactions != null)
            {
                foreach (SBTransaction item in SBTransactions)
                {
                    if (item.accountnumber == accno)
                    {
                        SBTransactions_temp.Add(item);
                        flag = 1;

                    }
                }
                if (flag == 0)
                {
                    //throw new Exception("Account not found");
                    Console.WriteLine(" No transactions  found for this account");
                    return null;
                }
                return SBTransactions_temp;
            }
            else 
            {
                Console.WriteLine(" No Transactions found ");
                return null;
            } 
          
        }

        public void NewAccount(SBAccount acc)
        {
            sbacc_creation = 1;
            long A_no = accountnumber_generation;
            Console.WriteLine(" Your Account Number......   "+A_no);
            Console.WriteLine(" \n Please enter Customer Name ");
            string C_name = Console.ReadLine();
            Console.WriteLine(" Please enter Customer Address ");
            string C_address = Console.ReadLine();
            Console.WriteLine(" Please enter Current balance ");
            decimal C_balance = Convert.ToDecimal(Console.ReadLine());
            accountnumber_generation = accountnumber_generation + 1;
            SBAccounts.Add(new SBAccount(A_no, C_name, C_address, C_balance));
            Console.WriteLine("\n\n\n\n\n\n            Your Account is created ......Thank You for choosing SBI......\n");
        }

        public void WithdrawAmount(long accno, decimal amt)
        {
            int flag = 0;
            foreach (SBAccount item in SBAccounts)
            {
                if (item.accountnumber == accno)
                {
                    if (item.currentbalance >= amt)
                    {
                        item.currentbalance = item.currentbalance - amt;
                        string T_id = "SBI_Withdraw_" + Count2++;
                        DateTime T_date = DateTime.Today;
                        string T_type = "Withdraw";

                        SBTransactions.Add(new SBTransaction(T_id, T_date, accno, amt, T_type));
                        flag = 1;
                    }
                    else 
                    {
                        flag = 1;
                        //throw new Exception("Not enough balance to withdraw");
                        Console.WriteLine("Not enough balance to withdraw");
                    }

                    
                }
            }
            if (flag == 0)
                Console.WriteLine("Account not Found");
        }
    }
}
