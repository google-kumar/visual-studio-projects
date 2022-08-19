using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BankLibrary;
using System.Globalization;



namespace BankRepositary
{
    public class BankRepositary : IBankRepositary
    {
        //static FileStream fs = new FileStream("SBI_File.txt", FileMode.Append, FileAccess.Write);
        //StreamWriter sw = new StreamWriter(fs);

        

        List<SBAccount> SBAccounts = new List<SBAccount>();
        List<SBTransaction> SBTransactions = new List<SBTransaction>();
        static int Count1 =Count_deposits() + 1;
        static int Count2 =Count_withdrawals() + 1;
        static long accountnumber_generation = AccountNumber_Generation();
       
        static int sbacc_creation = Count_SBAccounts() - 1;

        public static SqlConnection con;
        public static SqlCommand cmd;


        //public decimal C_balance { get; set; }


        public void DepositAmount(long accno, decimal amt)
        {
            int flag = 0;

            List<SBAccount> SBAccounts_temp = new List<SBAccount>();
            SBAccounts_temp = sql_GetAllAccounts();

            foreach (SBAccount item in SBAccounts_temp)
            {
                if (item.accountnumber == accno)
                {
                    //item.currentbalance = item.currentbalance + amt;

                    con = getcon();
                    cmd = new SqlCommand("update SBAccount set CurrentBalance = CurrentBalance + @Amt where AccountNumber = @Accno");
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Amt", amt);
                    cmd.Parameters.AddWithValue("@Accno", accno);
                    int i = cmd.ExecuteNonQuery();
                    


                    string T_id = "SBI_Deposit_" + Count1++;
                    string T_date = DateTime.Today.ToShortDateString();
                    string T_type = "Deposit";

                    con = getcon();
                    cmd = new SqlCommand("insert into SBTransaction values(@TransactionID,@TransactionDate,@AccountNumber,@Amount,@TransactionType)");
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@TransactionID", T_id);
                    cmd.Parameters.AddWithValue("@TransactionDate", T_date);
                    cmd.Parameters.AddWithValue("@AccountNumber", accno);
                    cmd.Parameters.AddWithValue("@Amount", amt);
                    cmd.Parameters.AddWithValue("@TransactionType", T_type);
                    i = cmd.ExecuteNonQuery();

                    Console.WriteLine("\n\t\t Transaction Successful .......\n");


                    //SBTransactions.Add(new SBTransaction(T_id, T_date, accno, amt, T_type));
                    flag = 1;
                }
            }
            if (flag == 0)
                Console.WriteLine("Account not Found");
        }

        public SBAccount GetAccountDetails(long accno)
        {
            int Flag = 0;

            List<SBAccount> SBAccounts_temp = new List<SBAccount>();
            SBAccounts_temp = sql_GetAllAccounts();

            foreach (SBAccount item in SBAccounts_temp)
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

            else
            {
                

                return sql_GetAllAccounts();

               // sw.WriteLine("All the savings bank accouncts of SBI are displayed " + DateTime.Now);
                
            }

            //return SBAccounts_temp;

        }

        public List<SBTransaction> GetTransactions(long accno)
        {
            int flag = 0;
            List<SBTransaction> SBTransactions_temp = new List<SBTransaction>();
            List<SBTransaction> SBTransactions_temp1 = new List<SBTransaction>();

            SBTransactions_temp1 = sql_GetTransactions();
            if (SBTransactions_temp1 != null)
            {
                foreach (SBTransaction item in SBTransactions_temp1)
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
            do
            {
                long A_no = accountnumber_generation + 1;
                
                Console.WriteLine(" Your Account Number......   " + A_no);
                Console.WriteLine(" \n Please enter Customer Name ");
                string C_name = Console.ReadLine();

                if (C_name.All(char.IsDigit) == true)
                { 
                     Console.WriteLine("\n\n    Your name should not contain numbers......\n      Please enter a valid name");
                     C_name = Console.ReadLine();
                    if (C_name.All(char.IsDigit) == true)
                    {
                        Console.WriteLine("\n Your input is not Valid...Please try after some times.......");
                        break;
                    }
                }

                Console.WriteLine(" Please enter Customer Address ");
                string C_address = Console.ReadLine();
                Console.WriteLine(" Please enter Current balance ");
                
                decimal C_balance = 0;
                try
                {
                    C_balance = Decimal.Parse(Console.ReadLine()); // 
                }
                catch (FormatException)
                {
                    Console.WriteLine("please enter only numbers");
                    try
                    {
                        C_balance = Decimal.Parse(Console.ReadLine()); //  
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                        break;
                    }

                }
                if (C_balance < 0)
                {
                    Console.WriteLine("\n\n     Amount should not be less than 0........\n please enter a vaild amount.........");

                    try
                    {
                        C_balance = Decimal.Parse(Console.ReadLine()); // 
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("please enter only numbers");
                        try
                        {
                            C_balance = Decimal.Parse(Console.ReadLine()); //  
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                            break;
                        }

                    }
                    if (C_balance < 0)
                    {
                        Console.WriteLine("\n Amount should not be less than 0 . Try again after sometimes.....");

                        break;
                    }

                }


                con = getcon();
                cmd = new SqlCommand("insert into SBAccount values(@AccountNumber,@CustomerName,@CustomerAddress,@CurrentBalance)");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@AccountNumber", A_no);
                cmd.Parameters.AddWithValue("@CustomerName", C_name);
                cmd.Parameters.AddWithValue("@CustomerAddress", C_address);
                cmd.Parameters.AddWithValue("@CurrentBalance", C_balance);
                int i = cmd.ExecuteNonQuery();

                //SBAccounts.Add(new SBAccount(A_no, C_name, C_address, C_balance));
                Console.WriteLine("\n\n\n\n\n\n            Your Account is created ......Thank You for choosing SBI......\n");

                
                //sw.WriteLine(" New account is created ("  + A_no  +") " + DateTime.Now);
                

            } while (sbacc_creation==0);
            
        }

        public void WithdrawAmount(long accno, decimal amt)
        {
            int flag = 0;

            List<SBAccount> SBAccounts_temp = new List<SBAccount>();
            SBAccounts_temp = sql_GetAllAccounts();

            foreach (SBAccount item in SBAccounts_temp)
            {
                if (item.accountnumber == accno)
                {
                    if (item.currentbalance >= amt)
                    {
                        //item.currentbalance = item.currentbalance - amt;
                        
                        con = getcon();
                        cmd = new SqlCommand("update SBAccount set CurrentBalance = CurrentBalance - @Amt where AccountNumber = @Accno");
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Amt", amt);
                        cmd.Parameters.AddWithValue("@Accno", accno);
                        int i = cmd.ExecuteNonQuery();



                        string T_id = "SBI_Withdraw_" + Count2++;
                        string T_date = DateTime.Today.ToShortDateString();
                        string T_type = "Withdraw";

                        con = getcon();
                        cmd = new SqlCommand("insert into SBTransaction values(@TransactionID,@TransactionDate,@AccountNumber,@Amount,@TransactionType)");
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@TransactionID", T_id);
                        cmd.Parameters.AddWithValue("@TransactionDate", T_date);
                        cmd.Parameters.AddWithValue("@AccountNumber", accno);
                        cmd.Parameters.AddWithValue("@Amount", amt);
                        cmd.Parameters.AddWithValue("@TransactionType", T_type);
                        i = cmd.ExecuteNonQuery();

                        Console.WriteLine("\n\t\t Transaction Successful .......\n");


                        //SBTransactions.Add(new SBTransaction(T_id, T_date, accno, amt, T_type));
                        flag = 1;
                    }
                    else
                    {
                        flag = 1;
                        //throw new Exception("Not enough balance to withdraw");
                        Console.WriteLine("\n\n\t\tNot enough balance to withdraw.........");
                    }
                    

                }
            }
            if (flag == 0)
                Console.WriteLine("Account not Found");
        }


        public List<SBAccount> sql_GetAllAccounts()
        {
            con = getcon();
            cmd = new SqlCommand("GetAllAccounts"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            List<SBAccount> SBAccounts_temp = new List<SBAccount>();

            dr.Read();

            while (dr.Read()) //number of rows
            {
                
                
                SBAccounts_temp.Add(new SBAccount((long)dr[0], (string)dr[1], (string)dr[2], (decimal)dr[3]));
   
            }
            return SBAccounts_temp;
        }

        public List<SBTransaction> sql_GetTransactions()
        {
            con = getcon();
            cmd = new SqlCommand("GetTransactions"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            List<SBTransaction> SBTransactions_temp = new List<SBTransaction>();

            while (dr.Read()) //number of rows
            {


                SBTransactions_temp.Add(new SBTransaction((string)dr[0], (string)dr[1], (long)dr[2], (decimal)dr[3], (string)dr[4]));

            }
            return SBTransactions_temp;
        }


        public static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=eurofins;Integrated Security=true");
            con.Open();
            return con;
        }

        public static long AccountNumber_Generation()
        {
            con = getcon();
            cmd = new SqlCommand("GetAllAccounts"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            long temp=0;
            while (dr.Read()) //number of rows
            {


                temp = (long)dr[0];

            }
            return temp;
        }
        public static int Count_SBAccounts()
        {
            con = getcon();
            cmd = new SqlCommand("GetAllAccounts"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            int temp = 0;
            while (dr.Read()) //number of rows
            {


                temp++;

            }
            return temp;
        }
        public static int Count_SBTransactions()
        {
            con = getcon();
            cmd = new SqlCommand("GetTransactions"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            int temp = 0;
            while (dr.Read()) //number of rows
            {


                temp++;

            }
            return temp;
        }
        public static int Count_withdrawals()
        {
            con = getcon();
            cmd = new SqlCommand("select count(*)  from SBtransaction where TransactionType = 'Withdraw'"); // defined in a sql query
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            int temp = 0;
            while (dr.Read()) //number of rows
            {


                temp = (int)dr[0];

            }
            return temp;
        }
        public static int Count_deposits()
        {
            con = getcon();
            cmd = new SqlCommand("select count(*)  from SBtransaction where TransactionType = 'Deposit'"); // defined in a sql query
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            int temp = 0;
            while (dr.Read()) //number of rows
            {


                temp = (int)dr[0];

            }
            return temp;
        }

        public void NewAccount_UnitTest(SBAccount acc)
        {
            
                long A_no = AccountNumber_Generation() + 1;

                
                string C_name = "test_case";

                string C_address = "test_address";
                
                decimal C_balance = 0;
                
                con = getcon();
                cmd = new SqlCommand("insert into SBAccount values(@AccountNumber,@CustomerName,@CustomerAddress,@CurrentBalance)");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@AccountNumber", A_no);
                cmd.Parameters.AddWithValue("@CustomerName", C_name);
                cmd.Parameters.AddWithValue("@CustomerAddress", C_address);
                cmd.Parameters.AddWithValue("@CurrentBalance", C_balance);
                int i = cmd.ExecuteNonQuery();

        }
    }
}
