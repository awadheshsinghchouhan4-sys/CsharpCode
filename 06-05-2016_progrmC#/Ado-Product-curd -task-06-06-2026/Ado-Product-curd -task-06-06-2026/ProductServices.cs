using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Product_curd__task_06_06_2026
{
    internal class ProductServices
    {
        public static  void AddProduct(SqlConnection con)
        {
            string Pname, Category;
            decimal Price;
            Console.WriteLine(" Enter the Product Name:  ");
            Pname = Console.ReadLine();

            Console.WriteLine(" Enter the Product category:  ");
            Category = Console.ReadLine();

            Console.WriteLine(" Enter the Price:  ");
            Price = Convert.ToDecimal(Console.ReadLine());

            string AdiingRecord = "Insert Into Products (ProductName,Category,Price) values (@pname , @Category ,@Price)";
            SqlCommand Cmd = new SqlCommand(AdiingRecord, con);
            Cmd.Parameters.AddWithValue("@pname", Pname);
            Cmd.Parameters.AddWithValue("@Category", Category);
            Cmd.Parameters.AddWithValue("@price", Price);

            int status = Cmd.ExecuteNonQuery();
            if (status >= 1)
            {
                Console.WriteLine(" The item update succesfully ");

            }
            
            Console.WriteLine(" Adding products succesfully....."+status);
        }

        // Updating price of a product
        public static void UpadtePrice(SqlConnection con)
        {
            
            Console.Write(" Enter The product name :");
            string pname = Console.ReadLine();
            Console.WriteLine(" Enter the Product Upadte Price :");
            decimal price = Convert.ToDecimal(Console.ReadLine().Trim());

            string queryupdate = " update  Products set price =@price where ProductName=@pname";
            SqlCommand cmd = new SqlCommand(queryupdate, con);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@pname", pname);

            int status = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (status >= 1)
            {
            Console.WriteLine(" The item update succesfully ");

            }

        }

        // Displaying a specific product info

        public static void DisplaySpecific(SqlConnection con)
        {
            Console.Write(" Enter The product name :");
            string pname = Console.ReadLine();
            string queryupdate = " select * from  Products  where ProductName=@pname";
            SqlCommand cmd = new SqlCommand(queryupdate, con);
            cmd.Parameters.AddWithValue("@pname", pname);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0].ToString()} {dr[1].ToString()}  {dr[2].ToString()} {dr[3].ToString()}");
                }
                dr.Close();
            }


        }
        // Display all products info

        public static void DisplayAllProductInfo(SqlConnection con)
        {

            string queryAll=" select * from  Products ";
            SqlCommand cmd = new SqlCommand(queryAll, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Console.WriteLine("ProductID \t ProductName \t ProductCategory \t ProductPrice");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0].ToString()}\t\t {dr[1].ToString()} \t\t {dr[2].ToString()}\t\t {dr[3].ToString()}");
                }
                dr.Close();
            }
            else
            {
                Console.WriteLine(" Detailed Not Found !!!");
            }


        }

        // Delete a specific product details with confirmation. 

        public static void DeleteRecord(SqlConnection con)
        {
            Console.WriteLine(" Enter The Product Name :");
            string Pname = Console.ReadLine();
            string deleteQuery = " Delete from Products where Productname=@pname";
            Console.WriteLine(" Are you Sure to want to delete the Product  y=> yes n=> no ");
            string useroption = Console.ReadLine();
            if(useroption.ToLower() == "y")
            {
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@pname", Pname);
                int status = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (status >= 1)
                {
                    Console.WriteLine(" Record delete Succesfully ");
                }
            }
        }
    }
}
