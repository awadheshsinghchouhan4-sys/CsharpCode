using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoSqlconn_task2_05_05_2026
{
    internal class methods
    {
       public static SqlConnection conn = new SqlConnection("Data Source=ACU-HYD-LT-1909 ;Initial Catalog=DemoDB;Integrated Security=True;");

       public  static void InsertRecord()
        {
            Console.WriteLine(" Enter the Name of Student :");
            string name = Console.ReadLine();

            Console.WriteLine(" Enter The Course :");
            string Course = Console.ReadLine();
            string insertQuerry = (" Insert Into Student values ('" + name + "','" + Course + "')");
           SqlCommand cmd = new SqlCommand(insertQuerry, conn);
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(" Inserting Records succesfully  " + result);

        }

        public static void UpdateRecord()
        {
            Console.WriteLine(" Enter the Id name :");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" Enter  the Name :");
            string name = Console.ReadLine();

            Console.WriteLine(" Enter ther Course :");
            string course = Console.ReadLine();

            string updateQuery = " Update student set name='" + name + "'" + ",'" + course + "'" + " where Id=" + id + ";";

            SqlCommand cmd = new SqlCommand(updateQuery, conn);
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine("Update the record Succesfully "+result);
        }

        public static void DeleteRecords()
        {
            Console.WriteLine(" enter the student ID that want to delete it :");
            int Id =Convert.ToInt32(Console.ReadLine());

            string deleteQuery = " Delete From Student where Id=" + Id+";";

            Console.WriteLine("ARE you realy want to delete the record y- YES / n- NO");
            string res = Console.ReadLine();
            if (res.ToLower() == "yes")
            {
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                int result = cmd.ExecuteNonQuery();// it give the result 0 if the query not executed 

                Console.WriteLine(" Record Deleted Succesfully"+result);

            }

            ;
        }



    }
}
