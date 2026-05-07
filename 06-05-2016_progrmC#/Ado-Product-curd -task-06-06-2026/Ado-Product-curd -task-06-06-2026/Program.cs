using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Product_curd__task_06_06_2026
{
    internal class Program
    {
    public static SqlConnection con = new SqlConnection(@"data source= ACU-HYD-LT-1909;initial catalog=ProductDb;Integrated Security=true");
        static void Main(string[] args)
        {
            try
            {
                con.Open();
                while (true)
                {
                    Console.WriteLine("1) Add product ");
                    Console.WriteLine("2)  Update Price of Product ");
                    Console.WriteLine("3) Display Specific record");
                    Console.WriteLine("4) Display All details");
                    Console.WriteLine("5) Delete Record ");
                    Console.Write(" Enter The Option :");
                    int opt = Convert.ToInt32(Console.ReadLine());
                    switch (opt)
                    {
                        case 1:
                            ProductServices.AddProduct(con);
                            break;
                        case 2:
                            ProductServices.UpadtePrice(con);
                            break;
                        case 3:
                            ProductServices.DisplaySpecific(con);
                            break;
                        case 4:
                            ProductServices.DisplayAllProductInfo(con);
                            break;

                        case 5:
                            ProductServices.DeleteRecord(con);
                            break;

                        default:
                            break;
                    }
                }

               



            }
            catch (SqlException Ex)
            {
                Console.WriteLine(Ex.Message);

            }
            finally
            {
                con.Close();
                Console.WriteLine("Connection Closed Succesfully ");
            }
        }

        // 

    }

}
