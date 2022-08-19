using System;

namespace shrivalli_tuition_center
{


        internal class student_detail
        {

            //private member variables

            int Rno;
            string Sname;
            long phone_num;
            string course;
            string Tname;
        
            static int count=1;
        
        
   

        public void AcceptDetails()
            {
                 
                Console.WriteLine("enter student's Rollnumber,Name,Phone_number,course name,tuitor name");
                Rno = Convert.ToInt32(Console.ReadLine());
                Sname = Console.ReadLine();
                phone_num = Convert.ToInt64(Console.ReadLine());
                course = Console.ReadLine();
                Tname = Console.ReadLine();
                

            }
            public void displayDetails()
            {
             
                Console.WriteLine("{0} Rno: {1} Name: {2} Phone_number: {3} Course: {4} Tuitor_name: {5} ",count++,Rno,Sname,phone_num,course,Tname);
            }

        }
    
   
}
