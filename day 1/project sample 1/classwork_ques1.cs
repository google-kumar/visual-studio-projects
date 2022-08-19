using System;

namespace project_sample_1
{
 
    internal class Classwork_ques1
    {
        public static void main()
        {
            Console.WriteLine("enter your name ....");
            string name = Console.ReadLine();
            
            Console.WriteLine("enter your tamil marks");
            int tamil = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter your english marks");
            int english = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter your maths marks");
            int maths = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter your science marks");
            int sci = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter your social science marks");
            int soc = Convert.ToInt32(Console.ReadLine());

            float ave = (tamil + english + maths + sci + soc)/5 ;
            
            string grade;
            if (ave < 40)
                grade = "fail";
            else if (ave > 90)
                grade = "outstanding";
            else if (ave > 65 && ave < 90)
                grade = "excellent";
            else if (ave > 40 && ave < 65)
                grade = "good";
            else
                grade = "not valid";

            Console.WriteLine("hello " + name);
            Console.WriteLine("your marks are....\n");
            Console.WriteLine("tamil : "+tamil);
            Console.WriteLine("english : "+ english);
            Console.WriteLine("maths : "+ maths);
            Console.WriteLine("science : "+ sci);
            Console.WriteLine("social science : "+ soc);

            Console.WriteLine("average : "+ ave);

            Console.WriteLine("grade : "+ grade);


        }

    }
}
