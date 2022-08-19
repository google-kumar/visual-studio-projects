using System;

namespace shrivalli_tuition_center
{
    internal class program
    {
        static void Main()
        {

            Console.WriteLine("\n Welcome to Shrivalli Tuition Center \n");
            int choice = 0;

            do {
                Console.WriteLine("select anyone option below: \n\t 1.Student details 2.Tuitor details 3.Tuitor salary details 4.exit");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 0)
                    Console.WriteLine(" ");
                else if (choice == 1)
                {
                    //salary_detail.count = 3; 

                    int n = 0;

                    Console.WriteLine("\n please enter the number of students");


                    n = Convert.ToInt32(Console.ReadLine());

                    student_detail[] s = new student_detail[n];
                    int choice1 = 0;
                    do
                    {
                        Console.WriteLine("\n enter 1 for create 2 for display 3 for exit");

                        choice1 = Convert.ToInt32(Console.ReadLine());

                        if (choice1 == 1)
                        {


                            for (int i = 0; i < n; i++)
                            {
                                s[i] = new student_detail();
                                student_detail s2 = new student_detail();
                                s[i].AcceptDetails();
                            }
                        }
                        else if (choice1 == 2)
                        {
                            for (int i = 0; i < n; i++)
                            {

                                Console.WriteLine("\nstudent details: ");
                                s[i].displayDetails();
                            }
                        }
                        else if (choice1 == 3)
                            break;
                        else
                        {
                            Console.WriteLine("not valid");
                        }

                        choice1 = -1;
                    } while (choice1 < 1 | choice1 > 2);

                    


                }
                else if (choice == 2)
                {


                    int n = 0;

                    Console.WriteLine("\n please enter the number of tuitors");


                    n = Convert.ToInt32(Console.ReadLine());

                    tuitor_details[] T = new tuitor_details[n];
                    int choice1 = 0;
                    do
                    {
                        Console.WriteLine("\n enter 1 for create 2 for display 3 for exit");

                        choice1 = Convert.ToInt32(Console.ReadLine());

                        if (choice1 == 1)
                        {


                            for (int i = 0; i < n; i++)
                            {
                                T[i] = new tuitor_details();
                                tuitor_details T2 = new tuitor_details();
                                T[i].AcceptDetails();
                            }

                        }
                        else if (choice1 == 2)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine("\nTuitor details: ");
                                T[i].displayDetails();
                            }
                        }
                        else if (choice1 == 3)
                            break;
                        else
                        {
                            Console.WriteLine("not valid");
                        }

                        choice1 = -1;
                    } while (choice1 < 1 | choice1 > 2);




                }
                else if (choice == 3)
                {

                    int n = 0;

                    Console.WriteLine("\n please enter the number of Tuitors");


                    n = Convert.ToInt32(Console.ReadLine());

                    salary_detail[] U = new salary_detail[n];
                    int choice1 = 0;
                    do
                    {
                        Console.WriteLine("\n enter 1 for create 2 for display 3 for exit");

                        choice1 = Convert.ToInt32(Console.ReadLine());

                        if (choice1 == 1)
                        {


                            for (int i = 0; i < n; i++)
                            {
                                U[i] = new salary_detail();
                                salary_detail u2 = new salary_detail();
                                U[i].AcceptDetails();
                            }
                        }
                        else if (choice1 == 2)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine("\nTuitor Salary details: ");
                                U[i].displayDetails();
                            }
                        }
                        else if (choice1 == 3)
                            break;
                        else
                        {
                            Console.WriteLine("not valid");
                        }

                        choice1 = -1;
                    } while (choice1 < 1 | choice1 > 2);




                }
                else if (choice == 4)
                {
                    Console.WriteLine("\n         Thank You ");
                    break;

                }
                else
                    Console.WriteLine("   invalid choice  ");
                choice = -1;

            } while (choice < 1 | choice > 3);
            
            GC.Collect();

            

        }
    }
}
