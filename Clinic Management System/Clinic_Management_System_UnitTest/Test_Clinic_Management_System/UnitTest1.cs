using System.Data.SqlClient;
using Clinic_Management_System;
using System;
using Test_Clinic_Management_System;
using Repositary;

namespace Test_Clinic_Management_System
{
    [TestFixture]
    public class Tests
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        public static Home_Menu obj;
        public static Admin_Menu obj2;
        
        int count = 0;

        [SetUp]
        public void Setup()
        {
            
            obj = new Home_Menu();
            obj2 = new Admin_Menu();
            
        }

        //whenever testing is done , Please remove that particular added dada from the data base

        [Test]
        public void Test_Add_Patient()
        {

            int previous = Count_Patient_Details();
            obj.add_patient();
            

            int now = Count_Patient_Details();
            Assert.AreEqual((previous + 1), now);
        }

        [Test]
        public void Test_Add_User()
        {

            int previous = Count_User_Details();
            obj2.add_user();


            int now = Count_User_Details();
            Assert.AreEqual((previous + 1), now);
        }

        public static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=Clinic_Management_System;Integrated Security=true");
            con.Open();
            return con;
        }
        public int Count_Patient_Details()
        {
            con = getcon();
            cmd = new SqlCommand("GetPatientDetails"); // defined in a sql query
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

        public int Count_User_Details()
        {
            con = getcon();
            cmd = new SqlCommand("GetUserDetails"); // defined in a sql query
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

    }
}