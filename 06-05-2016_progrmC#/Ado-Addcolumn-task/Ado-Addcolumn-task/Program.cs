using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Addcolumn_task
{
    internal class Program
    {
      public static   SqlConnection con = new SqlConnection(@"data source= ACU-HYD-LT-1909;initial catalog=employeedb;Integrated Security=true");

        static void Main(string[] args)
        {
            try
            {
                con.Open();
                Console.Write(" Enter The ColumnName :");
                string columnname = Console.ReadLine();
                AddingNewColumn(columnname);
            }
            catch (SqlException Ex )
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

        // metod for the adding  new column for the firstname on tblusers
        public static void AddingNewColumn(string columnname)
        {
            string AddColumnQuerry = $" Alter table TblUsers Add  {columnname} Varchar(30) ";
            SqlCommand cmd = new SqlCommand(AddColumnQuerry, con);
            //cmd.Parameters.AddWithValue("@columnname", columnname);
            int status = cmd.ExecuteNonQuery();

            Console.WriteLine(" Adding Column Succesfully"+status);
        }
    }
}
