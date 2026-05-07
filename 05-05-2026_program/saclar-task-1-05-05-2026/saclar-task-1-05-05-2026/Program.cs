using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saclar_task_1_05_05_2026
{
    internal class Program
    {
        static
            void Main(string[] args)
        {
            SqlConnection cn = new SqlConnection("Data Source= ACU-HYD-LT-1909 ;Initial Catalog=DemoDB;Integrated Security=True ");
            try
            {
            cn.Open();
                Console.WriteLine(" Plese enter the Course Name :");
                string course = Console.ReadLine();
                string Querry = " Select Count(*) from Student where Course='"+course+"'";

                SqlCommand cmd = new SqlCommand(Querry, cn);
                int result = Convert.ToInt32(cmd.ExecuteScalar());

                Console.WriteLine(" The Total Number of student is each coures is "+result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
