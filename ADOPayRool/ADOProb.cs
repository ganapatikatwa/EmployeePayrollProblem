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
        public static void CreateTable()
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB ; initial catalog=payroll_service ; integrated security= true");
                con.Open();
                string query = "create table employee_payroll (id int identity(1,1) primary key, name varchar(200),salary int, startdate date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successufully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
