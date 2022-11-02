using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Weather
{
    class Program
    {
        public static string connstring = "Data Source=ASTLPTWFH152\\SQLEXPRESS;Database=WeatherDB;Integrated Security=True";
        //Display Method
        public static void Display()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                Console.WriteLine("rajesh Database");

                string query = "select * from Weather";
                SqlCommand esh = new SqlCommand(query, conn);

                SqlDataReader readObj = esh.ExecuteReader();
                Console.WriteLine("locations_id \t-locations \t-temp \t-windSpeed \t-precipitation \t-feels \t-clouds");

                while(readObj.Read())
                {
                    Console.WriteLine(readObj[0].ToString() + "\t\t" + readObj[1].ToString() + "\t\t" + readObj[2].ToString() + "\t\t" + readObj[3].ToString() + "\t\t" + readObj[4].ToString() + "\t\t" + readObj[5].ToString() + "\t\t" + readObj[6].ToString());

                }
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("rajesh" +ex.Message);
            }
           
        }

        //Delete Method
        public static void delete()
        {
            try
            {

                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                Console.WriteLine("rajesh Database");

                Console.WriteLine("Which data you want to delete ?\n");
                int id = Convert.ToInt32(Console.ReadLine());
                SqlCommand delmet=new SqlCommand ($"delete Weather where locations_id = {id}",conn);

                Console.WriteLine(delmet.ExecuteNonQuery()+"result");

                Display();


            }
            catch(Exception ex)
            {

            }
        }
        //Insert Method
        public static void insert()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                Console.WriteLine("rajesh Database");

                SqlCommand cmd = new SqlCommand("insert into Weather values (@1,@2,@3,@4,@5,@6)", conn);

                Console.WriteLine("insert method\n");
                Console.WriteLine("enter the location name");
                string locations = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("1", locations));

                
                Console.WriteLine("enter the location name");
                string temp = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("2", temp));

                
                Console.WriteLine("enter the location name");
                string windSpeed = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("3", windSpeed));

                
                Console.WriteLine("enter the location name");
                string precipitation = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("4", precipitation));

                
                Console.WriteLine("enter the location name");
                string feels = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("5", feels));

                
                Console.WriteLine("enter the location name");
                string clouds = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("6", clouds));

                Console.WriteLine(cmd.ExecuteNonQuery()+"rows inserted");
                Display();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error - "+ex.Message);
            }
        }
        //Select Method
        public static void select()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                Console.WriteLine("rajesh Database");

                Console.WriteLine("which rows you want to select");
                
                Console.WriteLine("location name");
                string locations = Console.ReadLine();
                SqlCommand cmd=new SqlCommand ($"select * from Weather where locations ='{locations}'",conn);
                SqlDataReader readObj = cmd.ExecuteReader();
                Console.WriteLine("locations_id \t-locations \t-temp \t-windSpeed \t-precipitation \t-feels \t-clouds");


                while (readObj.Read())
                {
                    Console.WriteLine(readObj[0].ToString() + "\t\t" + readObj[1].ToString() + "\t\t" + readObj[2].ToString() + "\t\t" + readObj[3].ToString() + "\t\t" + readObj[4].ToString() + "\t\t" + readObj[5].ToString() + "\t\t" + readObj[6].ToString());

                }


            }
            catch(Exception ex)
            {
                Console.WriteLine("Error-" +ex.Message);
            }
        }
        //Update Method
        public static void update()
        {
            try
            {
                Display();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                Console.WriteLine("rajesh Database");

                Console.WriteLine("location name");
                string location = Console.ReadLine();
                Console.WriteLine("locations_id");
                int locations_id = Convert.ToInt32(Console.ReadLine());
                SqlCommand cmdobj = new SqlCommand($"update Weather set locations='{location}' where locations_id={locations_id} ", conn);

                Console.WriteLine(cmdobj.ExecuteNonQuery() + "result");
                Display();
            }
            
            catch(Exception ex)
            {
                Console.WriteLine("Error-" + ex.Message);
            }
        }
        public static void Main(string[] args)
        {
            //delete();
            //Display();
            //insert();
            //select();
            //update();


        }

    } 
}