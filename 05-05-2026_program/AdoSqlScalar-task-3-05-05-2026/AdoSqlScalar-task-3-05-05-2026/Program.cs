using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdoSqlScalar_task_3_05_05_2026
{
    internal class Program
    {
        static void Main(string[] args)
        { string connectionString = "Data Source= ACU-HYD-LT-1909 ;Initial Catalog=EmployeeDB;Integrated Security=True ";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string Query = " Select max(salary) from employees";
                SqlCommand cmd = new SqlCommand(Query, conn);

                int result = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine(" The Given Output is :"+result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
