using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adotask1_05_05_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // establishing connection to sql server 
            SqlConnection cn = new SqlConnection("Data Source=ACU-HYD-LT-1909 ;Initial Catalog=EmployeeDB;Integrated Security=True;");
            try
            {

                cn.Open();
                Console.WriteLine("Connection SQL Server using system ");

                string createtable = "Create table employees (EmployeeId  int identity(1,1) primary key , EmployeeName varchar(30) , Salary money )";

                SqlCommand cmd = new SqlCommand(createtable, cn);
                //int result = cmd.ExecuteNonQuery();
                //Console.WriteLine(result);// retuen -1 for table creation 

                Console.Write(" Enter The Employee name :");
                string name = Console.ReadLine();

                Console.Write(" Enter The Employee salary :");
                decimal salary = Convert.ToDecimal(Console.ReadLine());
                string insertdata = " Insert Into employees (EmployeeName , Salary) values('" + name + "'" + "," + salary + ")";
                SqlCommand cmd1 = new SqlCommand(insertdata, cn);

                int result = cmd1.ExecuteNonQuery();
                Console.WriteLine(" Inserting Record Succesfully "+ result);// it return the result 1       
                
                
            }
            catch (SqlException Ex)
            {

                Console.WriteLine(Ex.Message);
            }
            finally
            {
                cn.Close();
                Console.WriteLine(" Connection Establised Succesfully   ");
            }
        }
    }
}
