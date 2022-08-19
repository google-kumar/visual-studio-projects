using System;
using System.Data.SqlClient;
using System.Data;

namespace ADOEg
{
    internal class ADOexample
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        private static void DisconSelectData()
        {
            con = getcon();
            cmd = new SqlCommand("select * from cars",con);
            //cmd = new SqlCommand("select * from cars" ,"select * from suppliers" con) ;
            //cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds=new DataSet();
            da.Fill(ds);
            DataTable dt=ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                foreach (var item in dr.ItemArray)
                {
                    Console.Write(item + "  ");
                }
                Console.WriteLine();
            }

        }


        private static void SelectData()
        {
            con = getcon();
            cmd = new SqlCommand("spselectprd"); // defined in a sql query
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) //number of rows
            {
                for (int i = 0; i < dr.FieldCount; i++) //number of columns
                {
                    Console.Write(dr[i] + "  ");
                }
                Console.WriteLine();
            }
        }

        private static SqlConnection getcon()
        {
            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile($"appSettings.json", true, true);
            //var config = builder.Build();
            //con=new SqlConnection(config["ConnectionString"]);
            //con.Open();
            //return con;


            con = new SqlConnection("Data Source=.;Initial Catalog=eurofins;Integrated Security=true");
            con.Open();
            return con;
        }

        private static void InsertData()
        {
            Console.WriteLine("Enter car_id,car_name,car_type,owner_id");
            string car_id = Console.ReadLine();
            string car_name = Console.ReadLine();
            string car_type = Console.ReadLine();
            string owner_id = Console.ReadLine();
            con = getcon();
            cmd = new SqlCommand("insert into cars values(@car_id,@car_name,@car_type,@owner_id)");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@car_id", car_id);
            cmd.Parameters.AddWithValue("@car_name", car_name);
            cmd.Parameters.AddWithValue("@car_type", car_type);
            cmd.Parameters.AddWithValue("@owner_id", owner_id);
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i + " number of Row(s) affected");
        }

        static void Main(string[] args)
        {
            //InsertData();
            //SelectData();
            DisconSelectData();

        }
    }
}
