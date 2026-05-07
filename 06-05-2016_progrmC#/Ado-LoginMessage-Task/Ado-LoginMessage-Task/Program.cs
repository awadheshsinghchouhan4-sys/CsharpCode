using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_LoginMessage_Task
{
    internal class Program
    {
        public static SqlConnection con = new SqlConnection(@"data source= ACU-HYD-LT-1909;initial catalog=employeedb;Integrated Security=true");
        static void Main(string[] args)
        {
            try
            {
                con.Open();
                
                string name;

                name = UserValidate();

                Console.WriteLine($"\n Welcome {name}");

                

            }
            catch (SqlException Ex )
            {
                Console.WriteLine(Ex.Message);
               
            }
            finally
            {
                con.Close();
                Console.WriteLine("Connection Closed Succesfully ");
            }
        }

        // login Menu 
        public static string UserValidate( )
        {
            string username, password;
            Console.WriteLine(" Enter the UserName :");
            username = Console.ReadLine();

            Console.WriteLine(" Enter the Password  :");
            password = Console.ReadLine();

            string Queryvalid = $"Select username, password , firstname from TblUsers ";

            SqlCommand cmd = new SqlCommand(Queryvalid , con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (username == dr[0].ToString() && password == dr[1].ToString())
                    {
                        return dr[2].ToString();
                    }
                }
            }


            return "not found";
        }
    }
}
