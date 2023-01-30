using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoDotNet
{
    class Program
    {
        static void Main(string[] args)
        {

            DataBase db = new DataBase();
            SqlDataReader sdr=  db.readData("select * from Colors");
            db.ExcuteData("select * from Colors");
        }
    }
    class DataBase
    {
        public SqlConnection con { get; set; }
        public DataBase()
        {
            string statment = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            con = new SqlConnection(statment);

        }

        public SqlDataReader readData(string command)
        {
            SqlCommand cm = new SqlCommand(command, con);
            con.Open();
            //int ab = (int)cm.ExecuteScalar();

            SqlDataReader sdr = cm.ExecuteReader();
            SqlDataAdapter s = new SqlDataAdapter();
            s.Fill
            int s=sdr.FieldCount;
            while (sdr.Read())
            {
                Console.WriteLine(sdr["Color_Id"] + " " + sdr["Color_Name"]);
            }
            con.Close();
            return sdr;
        }
        public void ExcuteData(string command)
        {
            SqlCommand cm = new SqlCommand(command, con);
            con.Open();
           int a=   cm.ExecuteNonQuery();

           int ab=(int) cm.ExecuteScalar();
            con.Close();
        }
    }
}
