using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saclar_task2_05_05_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cn = new SqlConnection("Data Source= ACU-HYD-LT-1909 ;Initial Catalog=EmployeeDB;Integrated Security=True ");
            try
            {
            cn.Open();
                string Query = "Select max(Salary) from Employees";

                SqlCommand cmd = new SqlCommand(Query, cn);
                decimal result =Convert.ToDecimal(cmd.ExecuteScalar());
                Console.WriteLine(" The Total Salary Of the Employees Is "+result);
                     
            }
            catch (Exception Ex)
            {
                Console.WriteLine("The Error occurs : "+Ex.Message);
               
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
