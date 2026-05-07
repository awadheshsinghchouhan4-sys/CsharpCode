using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_UpdateColum_Task_06_06_2026
{
    internal class Program
    {
             public static SqlConnection con = new SqlConnection(@"data source= ACU-HYD-LT-1909;initial catalog=employeedb;Integrated Security=true");
        static void Main(string[] args)
        {
            try
            {
                con.Open();
              
                string username, name;
                Console.WriteLine(" Enter the username to give Name:");
                username = Console.ReadLine();
                Console.Write(" Enter the name :");
                name = Console.ReadLine();
                UpdatingColumFirstName(username,name);
            }
            catch (SqlException Ex)
            {

                Console.WriteLine(Ex.Message);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        
    }

        private static void UpdatingColumFirstName(string Username , string Name)
        {
            string UpdateQuerry = $"UPDATE TblUsers SET FirstName='{Name}' WHERE UserName='{Username}'";
            SqlCommand cmd = new SqlCommand(UpdateQuerry, con);
            int status = cmd.ExecuteNonQuery();
            
            if (status>=1)
            {
                Console.WriteLine(" Record Update Succesfully");
            }
            else
            {
                Console.WriteLine(" record Not Update succesfully ");
            }
        }
    }
}
