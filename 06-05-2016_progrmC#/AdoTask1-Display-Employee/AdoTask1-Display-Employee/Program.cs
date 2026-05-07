using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoTask1_Display_Employee
{
    internal class Program
    {
        public static    SqlConnection con = new SqlConnection(@"data source= ACU-HYD-LT-1909;initial catalog=DemoDB;Integrated Security=true");
        static void Main(string[] args)
        {
            try
            {
                con.Open();
                DisplayDetails();
            }
            catch (SqlException ex )
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Connection closed succesfuly ");
                con.Close();
            }


        }
        public static void DisplayDetails()
        {
            string fatchQuery = " Select * From student";
            SqlCommand cmd = new SqlCommand(fatchQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                Console.WriteLine(" StudentId \t StudentName \t StudentCourse \n");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]} \n");

                }
                dr.Close();
            }
            else {
                Console.WriteLine(" No Record Found ");
            }
        }
    }
}
