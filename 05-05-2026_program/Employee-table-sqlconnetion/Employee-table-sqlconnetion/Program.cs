using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Employee_table_sqlconnetion
{
    internal class Program
    {
        static void Main(string[] args)

        {
            try
            {
            SqlConnection cn = new SqlConnection("Data Source= ACU-HYD-LT-1909 ;Initial Catalog=DemoDB;Integrated Security=True ");
            cn.Open();
            Console.WriteLine(" The Connection Open Succesfully ");

              

              SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", cn);
              SqlDataReader dr = cmd.ExecuteReader();
              Console.WriteLine(" The employee Id \t Employee Name \t Department \t Salary ");
              while (dr.Read())
               {
                    Console.WriteLine($"{dr[0]}\t \t {dr[1]} \t \t {dr[2]} \t\t {dr[3]}");
                    //Console.WriteLine(dr["column name ]);
                    //Console.WriteLine(dr.GetInt32);
                    
                }

                cn.Close();

            }
            catch (SqlException ex )
            {

                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
