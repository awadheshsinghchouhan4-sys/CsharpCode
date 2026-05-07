using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoSqlconn_task2_05_05_2026
{
    internal class Program
    {
		methods m = new methods();
        static void Main(string[] args)
        {

			try
			{
                methods.conn.Open();

                Console.WriteLine(" Welcome to the Sql Connection ");
                Console.WriteLine("1) Insert Record");
                Console.WriteLine("2) Update Record");
                Console.WriteLine("3) Delete Record");
                Console.WriteLine(" Enter the option :");

                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {  case 1:
                       methods.InsertRecord();
                       break;

                    case 2:
                        methods.UpdateRecord();
                        break;

                    case 3:
                        methods.DeleteRecords();
                        break;





                default:
                        Console.WriteLine(" Invlid Option");
                        break;
                }


            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
