﻿using System;
using System.Collections.Generic;
using BankLibrary;



namespace BankRepositary
{
    public class client
    {
        public static void Main()
        {
            Console.WriteLine("\n.......................... WELCOME TO STATE BANK OF INDIA  ");

            int exit = 1;
            int transactions_count = 0;

            IBankRepositary bankRepositary = new BankRepositary();

            do
            {
                Console.WriteLine("\n Choose anyone below: \n\t1.Create new Account \n\t2.Get account details \n\t3.Display all Account details \n\t4.Deposit \n\t5.Withdraw \n\t6.Display transaction details \n\t7.exit  \n\n Please enter your choice .......");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            SBAccount sBAccount = new SBAccount();
                            bankRepositary.NewAccount(sBAccount);
                            break;
                        }
                    case 2:
                        {
                            int retry = 1;

                            do
                            {
                                Console.WriteLine(" Please enter the Account number ");
                                long accno=0;


                                try
                                {
                                    accno = Convert.ToInt64(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("please enter only numbers");
                                    try
                                    {
                                        accno = Convert.ToInt64(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                        break;
                                    }

                                }

                                if (accno < 1000000000 || accno > 9999999999)
                                {
                                    Console.WriteLine(" Account Number should be 10 digits ");
                                    Console.WriteLine(" Do you want to retry? enter 1 or enter 0 ");
                                    retry = Convert.ToInt32(Console.ReadLine());
                                    if (retry != 0 && retry != 1)
                                    {
                                        Console.WriteLine(" invalid choice ");
                                        break;
                                    }
                                }
                                else
                                {
                                    bankRepositary.GetAccountDetails(accno);
                                    retry = 0;
                                }


                                //if(accno.)



                            } while (retry == 1);


                            break;
                        }
                    case 3:
                        {
                            int count = 1;
                            List<SBAccount> SBAccounts_client = new List<SBAccount>();


                            SBAccounts_client = bankRepositary.GetAllAccounts();
                            //Console.WriteLine(SBAccounts_client.ToString());
                            if (SBAccounts_client != null)
                            {
                                foreach (SBAccount item in SBAccounts_client)
                                {
                                    Console.WriteLine(count++ + "......\n" + item.ToString() + "\n");
                                }
                            }


                            break;
                        }
                    case 4:
                        {
                            transactions_count = transactions_count + 1;

                            int retry = 1;

                            do
                            {
                                Console.WriteLine(" Please enter the Account number ");
                                long accno = 0;

                                try
                                {
                                    accno = Convert.ToInt64(Console.ReadLine()); 
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("please enter only numbers");
                                    try
                                    {
                                        accno = Convert.ToInt64(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                        break;
                                    }

                                }


                                if (accno < 1000000000 || accno > 9999999999)
                                {
                                    Console.WriteLine(" Account Number should be 10 digits and positive");
                                    Console.WriteLine(" Do you want to retry? enter 1 or enter 0 ");
                                    retry = Convert.ToInt32(Console.ReadLine());
                                    if (retry != 0 && retry != 1)
                                    {
                                        Console.WriteLine(" invalid choice ");
                                        break;
                                    }
                                }
                                else
                                {

                                    Console.WriteLine(" Please enter the Amount ");
                                    decimal amt = 0;

                                    try
                                    {
                                        amt = Convert.ToDecimal(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("please enter only numbers");
                                        try
                                        {
                                            amt = Convert.ToDecimal(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                            break;
                                        }

                                    }

                                    if (amt < 0)
                                    {
                                        Console.WriteLine("\n\n     Amount should not be less than 0........\n please enter a vaild amount.........");

                                        try
                                        {
                                            amt = Decimal.Parse(Console.ReadLine()); // 
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("please enter only numbers");
                                            try
                                            {
                                                amt = Decimal.Parse(Console.ReadLine()); //  
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                                break;
                                            }

                                        }
                                        if (amt < 0)
                                        {
                                            Console.WriteLine("\n Amount should not be less than 0 . Try again after sometimes.....");

                                            break;
                                        }

                                    }

                                    bankRepositary.DepositAmount(accno, amt);
                                    retry = 0;
                                }
                            } while (retry == 1);


                            break;
                        }
                    case 5:
                        {
                            transactions_count = transactions_count + 1;

                            int retry = 1;

                            do
                            {
                                Console.WriteLine(" Please enter the Account number ");
                                long accno = 0;

                                try
                                {
                                    accno = Convert.ToInt64(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("please enter only numbers");
                                    try
                                    {
                                        accno = Convert.ToInt64(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                        break;
                                    }

                                }

                                if (accno < 1000000000 || accno > 9999999999)
                                {
                                    Console.WriteLine(" Account Number should be 10 digits ");
                                    Console.WriteLine(" Do you want to retry? enter 1 or enter 0 ");
                                    retry = Convert.ToInt32(Console.ReadLine());
                                    if (retry != 0 && retry != 1)
                                    {
                                        Console.WriteLine(" invalid choice ");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(" Please enter the Amount ");
                                    decimal amt = 0;

                                    try
                                    {
                                        amt = Convert.ToDecimal(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("please enter only numbers");
                                        try
                                        {
                                            amt = Convert.ToDecimal(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                            break;
                                        }

                                    }

                                    if (amt < 0)
                                    {
                                        Console.WriteLine("\n\n     Amount should not be less than 0........\n please enter a vaild amount.........");

                                        try
                                        {
                                            amt = Decimal.Parse(Console.ReadLine()); // 
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("please enter only numbers");
                                            try
                                            {
                                                amt = Decimal.Parse(Console.ReadLine()); //  
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                                break;
                                            }

                                        }
                                        if (amt < 0)
                                        {
                                            Console.WriteLine("\n Amount should not be less than 0 . Try again after sometimes.....");

                                            break;
                                        }

                                    }

                                    bankRepositary.WithdrawAmount(accno, amt);
                                    retry = 0;
                                }
                            } while (retry == 1);


                            break;
                        }
                    case 6:
                        {
                            //if (transactions_count == 0)
                            //{
                            //    Console.WriteLine(" transaction history is empty ");
                            //    break;
                            //}
          
                            int retry = 1;
                            long accno = 0;

                            do
                            {
                                Console.WriteLine(" Please enter the Account number ");
                                

                                try
                                {
                                    accno = Convert.ToInt64(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("please enter only numbers");
                                    try
                                    {
                                        accno = Convert.ToInt64(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                        break;
                                    }

                                }

                                if (accno < 1000000000 || accno > 9999999999)
                                {
                                    Console.WriteLine(" Account Number should be 10 digits ");
                                    Console.WriteLine(" Do you want to retry? enter 1 or enter 0 ");
                                    retry = Convert.ToInt32(Console.ReadLine());
                                    if (retry != 0 && retry != 1)
                                    {
                                        Console.WriteLine(" invalid choice ");
                                        break;
                                    }
                                }
                                else
                                {
                                   
                                    retry = 0;
                                }
                            } while (retry == 1);


                            if (retry != 0)
                                break;


                            int count = 1;
                            List<SBTransaction> SBTransactions_client = new List<SBTransaction>();


                            SBTransactions_client = bankRepositary.GetTransactions(accno);

                            if (SBTransactions_client != null)
                            {
                                foreach (SBTransaction item in SBTransactions_client)
                                {
                                    Console.WriteLine(count++ + "......\n" + item.ToString() + "\n");
                                }
                            }



                            break;

                        }
                    case 7:

                        {

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("  ................. Invalid choice ................");
                            break;
                        }

                }



                exit = 7 - choice;

            } while (exit != 0);

            Console.WriteLine("\n.......................... Thank You... Visit Again...\n ..........................STATE BANK OF INDIA..... ");

        }
    }
}