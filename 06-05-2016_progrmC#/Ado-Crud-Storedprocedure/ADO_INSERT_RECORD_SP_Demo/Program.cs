using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO_INSERT_RECORD_SP_Demo
{
    class Program
    {
       static SqlConnection cn = new SqlConnection(@"data source=ACU-HYD-LT-1909;initial catalog=DemoDB;Integrated Security=true");

        static void Main(string[] args)
        {

            // Inserting a Record into table using Stored procedure 
            //connecting sql server

            string name, course;
            int id = 0;
            int tid;

            Console.WriteLine("1) Adding Record ");
            Console.WriteLine("2) Update Record");
            Console.WriteLine("3) Delete Record");
            Console.WriteLine("4) Display Detail");
            Console.Write(" choice option :");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("enter student name :");
                    name = Console.ReadLine();
                    Console.Write("Enter course :");
                    course = Console.ReadLine();
                    AddStudentWithSP(name, course);
                    break;
                case 2:
                    Console.Write("enter student name :");
                    name = Console.ReadLine();
                    Console.Write("Enter course :");
                    course = Console.ReadLine();
                    Console.Write(" Enter The id :");
                    tid = Convert.ToInt32(Console.ReadLine());
                    Updaterecords(name, course, tid);
                    break;

                case 3:
                    Console.Write(" Enter The id :");
                    tid = Convert.ToInt32(Console.ReadLine());
                    DeleteRecord(tid);
                    break;

                case 4:
                    DisplayDetails();
                    break;

                default:
                    break;

            }

                Console.ReadKey();

        }
       

        private static void AddStudentWithSP(string name,string course)
        {
            try 
            { 
                cn.Open();
                // Console.WriteLine("Connected to SQL server");
                //passing stored procedure name
                //-------------------
                //calling  the store proceduerevto find the indient 
                
                SqlCommand cmd1 = new SqlCommand("select max(id) from  student;", cn);
                
                int id =Convert.ToInt32(cmd1.ExecuteScalar());

                Console.WriteLine($"The your id is  :{ id+1}");

                SqlCommand cmd = new SqlCommand("sp_AddStudent", cn);
                //specifying that the command type is stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Course", course);
                //executing command (callign store procedure)
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                    Console.WriteLine("Record Saved Successfully..");
                else
                    Console.WriteLine("Record not Saved...!!!");

            }


            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        // upadtion of the record by using the id parameter
        private static void Updaterecords(string name , string course ,int id)
        {
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("Sp_UpdateStudent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@Course", course);
                cmd.Parameters.AddWithValue("@id", id);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                    Console.WriteLine("Record Update Successfully..");
                else
                    Console.WriteLine("Record not Update...!!!");

            }
            catch (SqlException ex )
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }

        // deletion Student record methods
        private static void DeleteRecord(int id)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Sp_deleteStudentDetaild", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    Console.WriteLine(" Delete Record Succesful ...");
                }
            }
            catch (SqlException Ex)
            {

                Console.WriteLine(Ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        // Display Details 
        private static void DisplayDetails()
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Sp_DisplayStudentDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr[0].ToString()} \t {dr[1].ToString()} \t\t {dr[2].ToString()}");
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

    }
}
