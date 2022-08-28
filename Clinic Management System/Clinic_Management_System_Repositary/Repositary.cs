using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Clinic_Management_System;
using System.Globalization;
using System.Text.RegularExpressions;

/*
 * All the declared methods in the Library are Defined here.
 * All the Business logics are done here,
 * All the methods and business logics of the client console needed are defined here
 * All the user inputs are validated here with special constraints
 * All the inputs are got from the user in this Class file, apart from the Action choosings in the home menu like "add patient" 
 * every input is validated whether it is in correct format and In range and meaningful
 * Every method is defined as Empty argument method and all the validation is done in this class, such that Console .EXE need not do any validation
 * All the doctors are Present for the whole day from 10AM to 4PM.
 * Every time when user enter the details He/She is given 2 chances to enter the data, as sometimes due to typing error the data may be not in correct format,
   so when ever the system thinks that the entered data is not in the correct format it makes the user know and gives one more chance to enter,
   only if the 2nd attempt also ends as failure control return to main menu.
*/

namespace Repositary
{

    //      All the Methods in all the Menu classes structured as a base of DO while loop,
    //        such that if the user action is not satisfied twice at a time , it results in returning to Home menu


    
   //Login menu validates the Username and Password,designed as case sensitive

    public class Login_Menu : I_Login_Menu
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        //this method validates the password and return true if password is correct
        public bool Password_check(string Username, string Password)
        {
            con = getcon();
            cmd = new SqlCommand("GetUserDetails"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) //number of rows
            {  
                if ((string)dr[0] == Username)
                {
                    if ((string)dr[3]==Password)
                        return true;    
                    else
                        return false;
                }
            }
            return false;
        }

        //This method checks whether the Username exists in the database, return true if it it does
        public bool Username_check(string Username)
        {
            con = getcon();
            cmd = new SqlCommand("GetUserDetails"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) //number of rows
            {
                if ((string)dr[0] == Username)
                    return true;
            }
            return false;
        }

        //Connection to the database
        public static SqlConnection getcon() 
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=Clinic_Management_System;Integrated Security=true");
            con.Open();
            return con;
        }
    }

    public class Home_Menu : I_Home_Menu
    {

        public static SqlConnection con;
        public static SqlCommand cmd;

        //All the doctors are Present for the whole day from 10AM to 4PM.
        //below are the total available slots for the appointment
        string[] Appointment_slots = new string[6] {"10Am-11Am","11Am-12Pm","12Pm-1Pm","1Pm-2Pm","2Pm-3Pm","3Pm-4Pm"};
        
        public void Add_Patient()
        {

            string FirstName, LastName; 
            char Sex;                               //gender is entered in the database as 'M','F','O'
            int Age;
            DateTime DateofBirth = DateTime.MinValue;

            do
            {
                string Patient_ID = PatientID_Generation();           // auto generation of patient ID,    Ex:"Patient_1"

                
                Console.WriteLine(" \n Please enter Patient's First Name ");
                FirstName = Console.ReadLine();

                // Name is validated such that it does not have numbers and special characters

                Regex r = new Regex("^[a-zA-Z ]+$");

                if (r.IsMatch(FirstName) == false)
                {
                    Console.WriteLine("\n\n    Your name should not contain numbers or special characters......\n      Please enter a valid name");
                    FirstName = Console.ReadLine();
                    if (r.IsMatch(FirstName) == false)
                    {
                        Console.WriteLine("\n Your input is not Valid...Please try after some times.......");
                        break;
                    }
                }

                Console.WriteLine(" \n Please enter Patient's Last Name ");
                LastName = Console.ReadLine();

                // Name is validated such that it does not have numbers and special characters

                if (r.IsMatch(LastName) == false)
                {
                    Console.WriteLine("\n\n    Your name should not contain numbers or special characters......\n      Please enter a valid name");
                    LastName = Console.ReadLine();
                    if (r.IsMatch(LastName) == false)
                    {
                        Console.WriteLine("\n Your input is not Valid...Please try after some times.......");
                        break;
                    }
                }

                Console.WriteLine(" Please enter Sex ....... {M,F,O} ");
                
                //Sex value should be any of {M,F,O}, any other value is not encouraged by the  method.


                try
                {
                    Sex = char.Parse(Console.ReadLine().ToUpper()); // 
                }
                catch (FormatException)
                {
                    Console.WriteLine(" It is not Valid , Please enter Sex ....... {M,F,O}");
                    try
                    {
                        Sex  = char.Parse(Console.ReadLine().ToUpper()); //  
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                        break;
                    }

                }

                if (!(Sex=='M' || Sex == 'F' || Sex == 'O'))
                {
                    Console.WriteLine("\n\n    Sex should not contain letter other than {M,F,O}......\n      Please enter a valid ");
                    Sex = char.Parse(Console.ReadLine().ToUpper());
                    if (!(Sex == 'M' || Sex == 'F' || Sex == 'O'))
                    {
                        Console.WriteLine("\n Your input is not Valid...Please try after some times.......");
                        break;
                    }
                }

                Console.WriteLine(" Please enter Age ");

                //Age should be greater than 0 and sholud be an integer

                try
                {
                    Age = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("please enter only numbers");
                    try
                    {
                        Age = Convert.ToInt32(Console.ReadLine()); //  
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                        break;
                    }

                }
                if (Age < 0)
                {
                    Console.WriteLine("\n\n     Age should not be less than 0........\n please enter a vaild age.........");

                    try
                    {
                        Age = Convert.ToInt32(Console.ReadLine()); // 
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("please enter only numbers");
                        try
                        {
                            Age = Convert.ToInt32(Console.ReadLine()); //  
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                            break;
                        }

                    }
                    if (Age < 0)
                    {
                        Console.WriteLine("\n Amount should not be less than 0 . Try again after sometimes.....");

                        break;
                    }

                }

                Console.WriteLine(" Please enter Date of birth ....... {DD/MM/YEAR}      Ex: 12/12/2000 ");

                //Date of birth is entered as datetime data type and converted into string and added in the database

                try
                {
                    DateofBirth = Convert.ToDateTime(Console.ReadLine()); 
                }
                catch (FormatException)
                {
                    Console.WriteLine(" It is not Valid , Please enter Date of birth in the format....... {DD/MM/YEAR}      Ex: 12/12/2000");
                    try
                    {
                        DateofBirth = Convert.ToDateTime(Console.ReadLine()); //  
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                        break;
                    }

                }

                string DateOfBirth = DateofBirth.ToShortDateString();


                // The validated datas are added in the database

                con = getcon();
                cmd = new SqlCommand("insert into Patient_Details values(@PatientID,@FirstName,@LastName,@Sex,@Age,@DateofBirth)");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@PatientID", Patient_ID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Sex", Sex);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@DateofBirth", DateOfBirth);
                int i = cmd.ExecuteNonQuery();

                Console.WriteLine("\n\n\n\n\n\n            Patient Detail is added  ......\n");
                Console.WriteLine(" Patient ID......   " + Patient_ID);



            } while (false);





        }

        public void Cancel_Appointment(string PatientID)
        {
            do
            {
                DateTime VisitDate = DateTime.MinValue;

                Console.WriteLine(" Please enter Visiting Date ....... {DD/MM/YEAR}      Ex: 12/12/2000 ");

                //Visiting date is validated here

                try
                {
                    VisitDate = Convert.ToDateTime(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n\n It is not Valid , Please enter Visiting Date in the format....... {DD/MM/YEAR}      Ex: 12/12/2000");
                    try
                    {
                        VisitDate = Convert.ToDateTime(Console.ReadLine()); //  
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                        break;
                    }

                }

                //Logic to ensure whether the entered date is yet to come

                string visitdate2 = VisitDate.ToShortDateString();

                var parameterDate = DateTime.ParseExact(visitdate2, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                var todaysDate = DateTime.Today;

                if (parameterDate < todaysDate)
                {
                    Console.WriteLine("\n\n Entered date is meaningless, as Date and Time Now:  " + DateTime.Now);
                    Console.WriteLine("Please enter a valid date  ");

                    try
                    {
                        VisitDate = Convert.ToDateTime(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(" It is not Valid , Please enter Date of visit in the format....... {DD/MM/YEAR}      Ex: 12/12/2000");
                        try
                        {
                            VisitDate = Convert.ToDateTime(Console.ReadLine()); //  
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                            break;
                        }

                    }

                    visitdate2 = VisitDate.ToShortDateString();

                    parameterDate = DateTime.ParseExact(visitdate2, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    todaysDate = DateTime.Today;

                    if (parameterDate < todaysDate)
                    {
                        Console.WriteLine("\n\n Entered date is meaningless, as Date and Time Now:  " + DateTime.Now);
                        Console.WriteLine("Please try after some times ");
                        break;
                    }
                }


                //checks whether Appoinment is found in the database,if yes shows all the appointments,else return to Home menu



                con = getcon();
                cmd = new SqlCommand("GetAppointmentDetails"); // defined in a sql query
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                string Visitdate = VisitDate.ToShortDateString();
                int count = 1;
                int flag = 0;                                  //It set flag to identify whether appointment data is found on the databsae
                while (dr.Read()) //number of rows
                {
                    if (((string)dr[0] == PatientID) && ((string)dr[4] == Visitdate))
                    { 
                        Console.WriteLine(count++ + "." + "\tAppointmentTime: " + (string)dr[5]);
                        flag = 1;
                    } 

                }
                
                if (flag == 0)
                {
                    Console.WriteLine(" No Appoinments Found for the given Data");
                    break;
                }





                // Time slot selection

                Console.WriteLine("Please select a time slot to cancel the Appointment     ");
                int choice = 0;

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("please enter only numbers from 1 to " + (count-1));
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
                if ((choice > 0) && (choice < count))
                {
                    //if the input is good in all the way to perform the task in expected way, it deletes the data in the database

                    con = getcon();
                    cmd = new SqlCommand("GetAppointmentDetails"); // defined in a sql query
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;
                    dr = cmd.ExecuteReader();

                   
                    int count2 = 1;

                    while (dr.Read()) //number of rows
                    {
                        if ((string)dr[0] == PatientID && (string)dr[4] == Visitdate && count2 == choice)
                        {
                            string AppointmentTime = (string)dr[5];
                            con = getcon();
                            cmd = new SqlCommand("DELETE FROM Appointment_Details WHERE PatientID = @patientID AND VisitDate = @Visitdate AND AppointmentTime = @AppointmentTime");
                            cmd.Connection = con; 
                            cmd.Parameters.AddWithValue("@PatientID", PatientID);
                            cmd.Parameters.AddWithValue("@VisitDate", Visitdate);
                            cmd.Parameters.AddWithValue("@AppointmentTime", AppointmentTime);
                            int i = cmd.ExecuteNonQuery();


                            Console.WriteLine("\n\n\n\n\n\n            Patient Appointment is Cancelled  ......\n");
                        }
                            
                        count2++;
                    }
                }
                else
                {
                    Console.WriteLine("\n your input is not valid . Try again after sometimes.....");
                    break;
                }
                    

            } while (false);

            

        }

        public void Schedule_Appointment()
        {
            string PatientID, Specialization, DoctorName=" ", DoctorID=" ";
            DateTime Visitdate=DateTime.MinValue;
            string AppointmentTime, VisitDate=" ";

            do
            {
                //The patient ID is got first and checked whether it exists in the database, only the Registed patients can shedule an appointment


                Console.WriteLine(" \n Please enter Patient's ID ");
                PatientID = Console.ReadLine();

                con = getcon();
                cmd = new SqlCommand("GetPatientDetails"); // defined in a sql query
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                int flag = 0;                            // to set flag whether the Patient Id is exist in the database
                while (dr.Read()) //number of rows
                {
                    if ((string)dr[0] == PatientID)
                        flag = 1;
                }

                if (flag == 0)
                {
                    Console.WriteLine(" \n Patient ID not found , Please enter correct Patient ID ");
                    PatientID = Console.ReadLine();

                    con = getcon();
                    cmd = new SqlCommand("GetPatientDetails"); // defined in a sql query
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;
                    dr = cmd.ExecuteReader();
                    flag = 0;
                    while (dr.Read()) //number of rows
                    {
                        if ((string)dr[0] == PatientID)
                            flag = 1;
                    }

                    if (flag == 0)
                    {
                        Console.WriteLine("\n\n\n Patient Id not fount , Please Try after some time \n");
                        break;
                    }
                }





                //if the patient Id is registered , he is shown the available Specializations 

                List<string> Specializations = new List<string>() {"General","InternalMedicine","Pediatrics","Orthopedics","Opthalmology"};
                Console.WriteLine("\n Choose anyone below: \n\t1.General \n\t2.Internal Medicine \n\t3.Pediatrics \n\t4.Orthopedics \n\t5.Opthalmology   \n\n Please enter your choice .......");


                int choice = 0;

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("please enter only numbers from 1 to " + 5);
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
                if (choice >= 1 && choice <= 5)
                {
                    Specialization=Specializations[choice-1];


                    //Based on the specializations the available doctor info is shown


                    con = getcon();
                    cmd = new SqlCommand("GetDoctorDetails"); // defined in a sql query
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;
                    dr = cmd.ExecuteReader();

                    int flag8 = 0;

                    int count = 1;
                    while (dr.Read()) //number of rows
                    {
                        if ((string)dr[4] == Specialization)
                        {
                            flag8 = 1;
                            Console.WriteLine(count++ + "......\n" + "\tDoctor ID: " + (string)dr[0] + "\n\tFirst Name: " + (string)dr[1] + "\n\tLast Name: " + (string)dr[2] + "\n\tSex: " + (string)dr[3] + "\n\tSpecialization: " + (string)dr[4] + "\n\tVisiting Hours From: " + (string)dr[5] + "\n\t                To: " + (string)dr[6] + "\n");
                        }
                           

                    }
                    if (flag8 == 0)
                    {
                        Console.WriteLine("\n\n Sorry no available doctors at this time for the specialization......");
                        break;
                    }

                    int choice1 = 0;
                    Console.WriteLine("Please enter your choice...........");

                    try
                    {
                        choice1 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("please enter only numbers from 1 to " + (count-1));
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

                    //based on the user input, after validation the doctor's name and Id is selected to check if he is available 


                    if (choice1 >= 1 && choice1 < count)
                    {
                        con = getcon();
                        cmd = new SqlCommand("GetDoctorDetails"); // defined in a sql query
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;
                        dr = cmd.ExecuteReader();


                        int count2 = 0;
                        while (dr.Read()) //number of rows
                        {
                            if ((string)dr[4] == Specialization)
                            {
                                count2++;
                                if (count2 == choice1)
                                {
                                    DoctorID = (string)dr[0];
                                    DoctorName= (string)dr[1] + (string)dr[2];
                                }
                                 
                            }
                               

                        }
                    }
                    else
                    {
                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");
                        break;
                    }



                    //The Visiting date is got and available slots of the day are shown.
                    //If the date has no available slots the user is advised to select a new visit date,
                    //using do while loop it is possible to select a applicable date until a proper date is selected continuously


                    int count3=1,Dateselection=0;
                    int LoopStart_Firsttime = 1;

                    int flagout;
                    do
                    {
                        flagout = 0;

                        Console.WriteLine(" Please enter Date of Visit ....... {DD/MM/YEAR}      Ex: 12/12/2000 ");


                        //Option is provided here to quit to Home menu if the Visiting date is not suitable to the user
                        
                        if(LoopStart_Firsttime==0)
                        {
                            Console.WriteLine("Please Enter 1 to continue or anyother number to quit....");
                            try
                            {
                                flagout = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid choice.....Please Try After sometimes...");
                                break;
                            }
                            
                        }

                        



                        try
                        {
                            Visitdate = Convert.ToDateTime(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(" It is not Valid , Please enter Date of visit in the format....... {DD/MM/YEAR}      Ex: 12/12/2000");
                            try
                            {
                                Visitdate = Convert.ToDateTime(Console.ReadLine()); //  
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                break;
                            }

                        }

                        //Logic to ensure whether the entered date is yet to come

                        
                        string visitdate2 = Visitdate.ToShortDateString();

                        var parameterDate = DateTime.ParseExact(visitdate2, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        var todaysDate = DateTime.Today;

                        if (parameterDate < todaysDate)
                        {
                            Console.WriteLine("\n\n Entered date is meaningless, as Date and Time Now:  " + DateTime.Now);
                            Console.WriteLine("Please enter a valid date  ");

                            try
                            {
                                Visitdate = Convert.ToDateTime(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine(" It is not Valid , Please enter Date of visit in the format....... {DD/MM/YEAR}      Ex: 12/12/2000");
                                try
                                {
                                    Visitdate = Convert.ToDateTime(Console.ReadLine()); //  
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                                    break;
                                }

                            }

                            visitdate2 = Visitdate.ToShortDateString();

                            parameterDate = DateTime.ParseExact(visitdate2, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            todaysDate = DateTime.Today;

                            if (parameterDate < todaysDate)
                            {
                                Console.WriteLine("\n\n Entered date is meaningless, as Date and Time Now:  " + DateTime.Now);
                                Console.WriteLine("Please try after some times ");
                                break;
                            }
                        }

                        VisitDate = Visitdate.ToShortDateString();

                        Console.WriteLine("\n Applicable Slots of the day for the mentioned Doctor\n");
                        count3 = 1;
                        foreach (string item in Appointment_slots)
                            Console.Write(count3++ + "." + item + "  ");

                        con = getcon();
                        cmd = new SqlCommand("Select AppointmentTime from Appointment_Details where VisitDate=@VisitDate and DoctorID=@DoctorID"); 
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                        cmd.Parameters.AddWithValue("@VisitDate", VisitDate);
                        dr = cmd.ExecuteReader();

                        int count4 = 1;
                        while (dr.Read()) //number of rows
                        {
                            if (count4 == 1)
                                Console.WriteLine("\nNot available slots are.....");

                            Console.WriteLine("          -->......" + (string)dr[0]);
                            count4++;

                        }
                        if (count4 == 7)
                        {
                            Console.WriteLine("All slots are booked.. Please choose a different Date...");

                            Console.WriteLine("Please Enter 1 to choose a different date ....");
                            try
                            {
                                flagout = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid choice.....Please Try After sometimes...");
                                break;
                            }

                            continue;
                        }
                        else
                            Dateselection = 1;




                        LoopStart_Firsttime = 0;

                        Console.WriteLine("Please Enter 1 to choose a time slot ....");
                        try
                        {
                            flagout = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid choice.....Please Try After sometimes...");
                            break;
                        }



                    } while (flagout != 1 || Dateselection!=1 );

                    

                    if (Dateselection == 0)
                        break;

                    //Only if the proper date is selected it allows the user to select  an available slot
                    //until a proper slot is selected the user can continuously try to book a slot as like the date selection



                    int choice5 = 0;
                    Console.WriteLine("Please enter your choice...........");

                    try
                    {
                        choice5 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("please enter only numbers from 1 to " + (count3-1));
                        try
                        {
                            choice5 = Convert.ToInt32(Console.ReadLine()); //  
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                            break;
                        }

                    }
                    if (choice5 >= 1 && choice5 < count3)
                    {
                        AppointmentTime = Appointment_slots[choice5-1];


                        con = getcon();
                        cmd = new SqlCommand("Select AppointmentTime from Appointment_Details where VisitDate=@VisitDate and DoctorID=@DoctorID"); // defined in a sql query
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                        cmd.Parameters.AddWithValue("@VisitDate", VisitDate);
                        dr = cmd.ExecuteReader();

                        int breakit = 0;
                        while (dr.Read()) //number of rows
                        {
                            
                            
                            if ((string)dr[0] == AppointmentTime)
                            {
                                Console.WriteLine("\n\nThe Choosen Time slot is not available.. please try after some times.....");
                                breakit=1;
                                break;
                            }
                                

                        }
                        if (breakit == 1)
                            break;
                        else 
                        {
                            //to check if the patient has an appointment with an other doctor at the same time
                            int Breaks = 0;
                            con = getcon();
                            cmd = new SqlCommand("Select * from Appointment_Details where  PatientID=@PatientID and VisitDate=@VisitDate and AppointmentTime=@AppointmentTime"); // defined in a sql query
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@PatientID", PatientID);
                            cmd.Parameters.AddWithValue("@VisitDate", VisitDate);
                            cmd.Parameters.AddWithValue("@AppointmentTime", AppointmentTime);
                            dr = cmd.ExecuteReader();

                            while (dr.Read()) //number of rows
                            {
                                Breaks = 1;
                            }

                            if (Breaks == 1)
                            { 
                                 Console.WriteLine("\n Sorry, The patient already has an appointment at this time with an other doctor \n");
                                 break;
                            }



                            //if everything is good to go, the appointment is booked and added in the database here

                            con = getcon();
                            cmd = new SqlCommand("insert into Appointment_Details values(@PatientID,@Specialization,@DoctorID,@DoctorName,@VisitDate,@AppointmentTime)");
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@PatientID", PatientID);
                            cmd.Parameters.AddWithValue("@Specialization", Specialization);
                            cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                            cmd.Parameters.AddWithValue("@DoctorName", DoctorName);
                            cmd.Parameters.AddWithValue("@VisitDate", VisitDate);
                            cmd.Parameters.AddWithValue("@AppointmentTime", AppointmentTime);
                            int i = cmd.ExecuteNonQuery();

                            
                            Console.WriteLine("\n\n\n\n\n\n            Appointment Detail is added  ......\n");   
                        }

                    }
                    else
                    {
                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");
                        break;
                    }

                   
                }
                else
                {
                    Console.WriteLine("\n your input is not valid . Try again after sometimes.....");
                    break;
                }

            } while (false);
        }

        public void View_Doctors()
        {
            con = getcon();
            cmd = new SqlCommand("GetDoctorDetails"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            
            int count = 1;
            while (dr.Read()) //number of rows
            {
                
                Console.WriteLine(count++ + "......\n" + "\tDoctor ID: " + (string)dr[0] + "\n\tFirst Name: " + (string)dr[1] + "\n\tLast Name: " + (string)dr[2] + "\n\tSex: " + (string)dr[3] + "\n\tSpecialization: " + (string)dr[4] + "\n\tVisiting Hours From: " + (string)dr[5] + "\n\t                To: " + (string)dr[6] + "\n");

            }
            if (count == 1)
                Console.WriteLine("No Doctors Available at this time.......");
        }


        public static string PatientID_Generation()
        {
            con = getcon();
            cmd = new SqlCommand("GetPatientDetails"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            int temp = 1;
            while (dr.Read()) //number of rows
            { 
                temp++;
            }
            return "Patient_" + temp;
        }

        

        public static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=Clinic_Management_System;Integrated Security=true");
            con.Open();
            return con;
        }


        // This method is just for testing purpose for the developer to check whether the actual Add_patient() method is working fine
        public void add_patient()
        {
            String Patient_ID = "Testcase_1", FirstName = "Test", LastName = "Case", DateOfBirth = "00/00/0000";
            char Sex = 'M';
            int Age = 0;

            con = getcon();
            cmd = new SqlCommand("insert into Patient_Details values(@PatientID,@FirstName,@LastName,@Sex,@Age,@DateofBirth)");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@PatientID", Patient_ID);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Sex", Sex);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@DateofBirth", DateOfBirth);
            int i = cmd.ExecuteNonQuery();

        }
    }


    //only Admin(developer or clinic management or the authorized user) can navigate to Admin menu,
    //and can add a user(Front end staff details of the clinic) or Doctor details 
    public class Admin_Menu : I_Admin_Menu
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        //All the validation logics  in these methods are same as done in the above methods, not commented below anywhere
        public void Add_Doctors()
        {
            string DoctorID = DoctorID_Generation();
            char Sex; 
            string Specialization=" ", VisitingHoursFrom="10:00", VisitingHoursTo="04:00";

            do
            {

                Console.WriteLine(" \n Please enter Doctor's First Name ");
                string FirstName = Console.ReadLine();

                Regex r = new Regex("^[a-zA-Z ]+$");

                if (r.IsMatch(FirstName) == false)
                {
                    Console.WriteLine("\n\n    Your name should not contain numbers or special characters......\n      Please enter a valid name");
                    FirstName = Console.ReadLine();
                    if (r.IsMatch(FirstName) == false)
                    {
                        Console.WriteLine("\n Your input is not Valid...Please try after some times.......");
                        break;
                    }
                }

                Console.WriteLine(" \n Please enter Doctor's Last Name ");
                string LastName = Console.ReadLine();


                if (r.IsMatch(LastName) == false)
                {
                    Console.WriteLine("\n\n    Your name should not contain numbers or special characters......\n      Please enter a valid name");
                    LastName = Console.ReadLine();
                    if (r.IsMatch(LastName) == false)
                    {
                        Console.WriteLine("\n Your input is not Valid...Please try after some times.......");
                        break;
                    }
                }

                Console.WriteLine(" Please enter Sex ....... {M,F,O} ");


                try
                {
                    Sex = char.Parse(Console.ReadLine().ToUpper()); // 
                }
                catch (FormatException)
                {
                    Console.WriteLine(" It is not Valid , Please enter Sex ....... {M,F,O}");
                    try
                    {
                        Sex = char.Parse(Console.ReadLine().ToUpper()); //  
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n your input is not valid . Try again after sometimes.....");

                        break;
                    }

                }

                if (!(Sex == 'M' || Sex == 'F' || Sex == 'O'))
                {
                    Console.WriteLine("\n\n    Sex should not contain letter other than {M,F,O}......\n      Please enter a valid ");
                    Sex = char.Parse(Console.ReadLine().ToUpper());
                    if (!(Sex == 'M' || Sex == 'F' || Sex == 'O'))
                    {
                        Console.WriteLine("\n Your input is not Valid...Please try after some times.......");
                        break;
                    }
                }

                List<string> Specializations = new List<string>() { "General", "InternalMedicine", "Pediatrics", "Orthopedics", "Opthalmology" };
                Console.WriteLine("\n Choose anyone below: \n\t1.General \n\t2.Internal Medicine \n\t3.Pediatrics \n\t4.Orthopedics \n\t5.Opthalmology   \n\n Please enter your choice .......");


                int choice = 0;

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("please enter only numbers from 1 to " + 5);
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
                    Specialization = Specializations[choice - 1];
                }
                else
                {
                    Console.WriteLine("\n\n Invalid Choice  ... Please try after some time");
                    break;
                }

                con = getcon();
                cmd = new SqlCommand("insert into Doctor_Details values(@DoctorID,@FirstName,@LastName,@Sex,@Specialization,@VisitingHours_From,@VisitingHours_To)");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Sex", Sex);
                cmd.Parameters.AddWithValue("@Specialization", Specialization);
                cmd.Parameters.AddWithValue("@VisitingHours_From", VisitingHoursFrom);
                cmd.Parameters.AddWithValue("@VisitingHours_To", VisitingHoursTo);
                int i = cmd.ExecuteNonQuery();

                
                Console.WriteLine("\n\n\n\n\n\n            Doctor Detail is added  ......\n");
                Console.WriteLine("\n      Doctor ID:   "+DoctorID);

            } while (false);

            
        }

        public void Add_User()
        {
            do
            {

                // for all the  users user id is system generated to maintain professional way of creating it, avoiding indiscipline ids 

                string UserName = UserName_Generation();

                Console.WriteLine(" \n Please enter User's First Name ");
                string FirstName = Console.ReadLine();

                Regex r = new Regex("^[a-zA-Z ]+$");

                if (r.IsMatch(FirstName) == false)
                {
                    Console.WriteLine("\n\n    Your name should not contain numbers or special characters......\n      Please enter a valid name");
                    FirstName = Console.ReadLine();
                    if (r.IsMatch(FirstName) == false)
                    {
                        Console.WriteLine("\n Your input is not Valid...Please try after some times.......");
                        break;
                    }
                }

                Console.WriteLine(" \n Please enter User's Last Name ");
                string LastName = Console.ReadLine();


                if (r.IsMatch(LastName) == false)
                {
                    Console.WriteLine("\n\n    Your name should not contain numbers or special characters......\n      Please enter a valid name");
                    LastName = Console.ReadLine();
                    if (r.IsMatch(LastName) == false)
                    {
                        Console.WriteLine("\n Your input is not Valid...Please try after some times.......");
                        break;
                    }
                }

                Console.WriteLine(" \n Please create a new password....... note: It should contain @");
                string Password=Console.ReadLine();

                if (Password.Contains('@') == false)
                {
                    Console.WriteLine("\n\n   Password should contain @  ......\n      Please enter a valid one");
                    FirstName = Console.ReadLine();
                    if (Password.Contains('@') == false)
                    {
                        Console.WriteLine("\n Your input is not Valid...Please try after some times.......");
                        break;
                    }
                }
                else 
                {
                    con = getcon();
                    cmd = new SqlCommand("insert into User_Details values(@UserName,@FirstName,@LastName,@Password)");
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    int i = cmd.ExecuteNonQuery();

                    
                    Console.WriteLine("\n\n\n\n\n\n            User Detail is added  ......\n");
                    Console.WriteLine("\nUsername:  "+UserName +"   Password:   "+Password);
                }

            } while (false);

            
        }


        public static string DoctorID_Generation()
        {
            con = getcon();
            cmd = new SqlCommand("GetDoctorDetails"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            int temp = 1;
            while (dr.Read()) //number of rows
            {
                temp++;
            }
            return "Doctor_" + temp;
        }

        public static string UserName_Generation()
        {
            con = getcon();
            cmd = new SqlCommand("GetUserDetails"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            int temp = 1;
            while (dr.Read()) //number of rows
            {
                temp++;
            }
            return "User_" + temp;
        }

        public static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=Clinic_Management_System;Integrated Security=true");
            con.Open();
            return con;
        }

        // This method is just for testing purpose for the developer to check whether the actual Add_User() method is working fine
        public void add_user()
        {
            string UserName = "TestUser_1", FirstName = "Test", LastName = "Case", Password = "Password@";

            con = getcon();
            cmd = new SqlCommand("insert into User_Details values(@UserName,@FirstName,@LastName,@Password)");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Password", Password);
            int i = cmd.ExecuteNonQuery();

            Console.WriteLine("\n\n\n\n\n\n            User Detail is added  ......\n");
            Console.WriteLine("\nUsername:  " + UserName + "   Password:   " + Password);
        }
    }

}