using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Department_Store_Library;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Department_Store_Library.Migrations;
//using Department_Store_Library.Models;

namespace Department_Store_Console
{
    internal class Program
    {

        


        //public static Department_Store_Context db = new Department_Store_Context();
        public static void Main()
        {
            string UserName, Password;

            bool exit_status = true;


            do
            {
                exit_status = true;
                Console.WriteLine("\n..........................Welcome TO Sabari Department Store.......................  \n");
                Console.WriteLine("           Login:\n\nUser name:    ");
                UserName = Console.ReadLine();
                if (UserName == "admin")
                {
                    Console.WriteLine("Password:    ");
                    Password = Console.ReadLine();


                    //If the username is "admin", and password is "admin@123" , it takes user to the Admin menu where add user or add doctor operations can be performed
                    //Only authorized persons or Developer or the management can perform the above tasks


                    if (Password == "admin@123")
                    {
                        do
                        {

                            Console.WriteLine("\n\n\n\n\n\n           Admin Menu\n\n   1.Add a Product  \n    2.Delete a product    \n    3.Update a Product    \n    4.Display the Products     \n    5.Logout    \n\nPlease enter your choice......");
                            Products p = new Products();
                            int choice = 0;
                            try
                            {
                                choice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("please enter only numbers from 1 to 5");
                                try
                                {
                                    choice = Convert.ToInt32(Console.ReadLine()); //  
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                    break;
                                }

                            }
                            if ((choice > 0) && (choice < 6))
                            {
                                if (choice == 1)
                                    DB_Operations.Add_Products();
                                else if (choice == 2)
                                    DB_Operations.DeleteProduct();
                                else if (choice == 3)
                                    DB_Operations.UpdateProducts();
                                else if (choice == 4)
                                    DB_Operations.DisplayProducts();
                                else
                                    break;

                            }
                            else
                            {
                                Console.WriteLine("\n\nInvalid choice......Please try after sometimes....");
                                break;
                            }

                        } while (true);



                    }
                    else
                    {
                        Console.WriteLine("\n\nIncorrect Password.....Please try after some times.......");
                        break;
                    }

                }
                else if (UserName == "vishnu")
                {
                    Console.WriteLine("Password:    ");
                    Password = Console.ReadLine();


                    //If the username is "admin", and password is "admin@123" , it takes user to the Admin menu where add user or add doctor operations can be performed
                    //Only authorized persons or Developer or the management can perform the above tasks


                    if (Password == "1234")
                    {
                        int Exit = 1;
                        do
                        {

                            float Total_amount = 0;
                            Console.WriteLine("\n\n   Billing Section :");
                            int stop = 1;
                            do
                            {

                                Total_amount = Total_amount + DB_Operations.Calculate();
                                Console.WriteLine("Press 0 to Stop......");
                                stop = Convert.ToInt32(Console.ReadLine());
                                if (stop == 0)
                                    break;
                                else
                                    continue;

                            } while (true);

                            Console.WriteLine("\n\nBill Amount: " + Total_amount + "\n");

                            Console.WriteLine("Press 0 to Exit ......");
                            Exit = Convert.ToInt32(Console.ReadLine());
                            if (Exit == 0)
                                break;
                            else
                                continue;

                        } while (true);



                    }
                    else
                    {
                        Console.WriteLine("\n\nIncorrect Password.....Please try after some times.......");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\nUser name does not Exist.....Try after some times.....");
                    break;
                }


                Console.WriteLine("Please enter 1 to logoff 0 to Continue");
                int choice1 = 0;
                try
                {
                    choice1 = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("please enter only number 0 or 1");
                    try
                    {
                        choice1 = Convert.ToInt32(Console.ReadLine()); //  
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                        break;
                    }

                }
                if (choice1 == 1)
                {
                    exit_status = false;

                }
                else if (choice1 == 0)
                    continue;
                else
                {
                    Console.WriteLine("\n\nInvalid choice......Please try after sometimes....");
                    break;
                }



            } while (exit_status);

        }
    }
}
