using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOPayRool
{
    public class ADOProb
    {
        public static void CreateDatabase()
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB ; initial catalog=master ; integrated security= true");
                con.Open();
                string query = "Create database payroll_service";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Base Created Successufully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        
    }
}
