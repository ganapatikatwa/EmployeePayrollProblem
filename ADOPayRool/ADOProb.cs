using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
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
        public static SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB ; initial catalog=payroll_service ; integrated security= true");
        public static void InsertRecord()
        {
            try
            {
                EmpSet model = new EmpSet();
                Console.WriteLine("Enter Employee Nmae");
                model.name = Console.ReadLine();
                Console.WriteLine("Enter Salary");
                model.salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Joining date");
                model.startdate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Gender");
                model.gender = Console.ReadLine();
                Console.WriteLine("Enter Phone Number");
                model.phonenumber=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Address");
                model.address = Console.ReadLine();
                Console.WriteLine("Department");
                model.department = Console.ReadLine();
                Console.WriteLine("Basic Pay");
                model.BasicPay=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Deduction");
                model.Deduction=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Taxable Pay");
                model.TaxablePay=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Income Tax");
                model.IncomeTax=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Net Pay");
                model.NetPay=Convert.ToInt32(Console.ReadLine());
                con.Open();
                string query = "insert into employee_payroll values('" + model.name + "'," + model.salary + ",'" +model.startdate+ "'," +
                    "'" + model.gender + "'," + model.phonenumber +", '" + model.address+"','"+model.department+ "'," + model.BasicPay + "," + model.Deduction+","+model.TaxablePay+","+model.IncomeTax+","+model.NetPay+")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record inserted Successufully");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void RetriveData()
        {
            try
            {
                con.Open();
                string query = ("select * from employee_payroll");
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    Console.WriteLine("Records From Employee PayRoll Table");
                    Console.WriteLine("ID\tName\tSalary\tSatrtDate\tgender\tphonenumber\taddress\tdepartment" +
                        "\tBasicPay\tDeduction\tTaxablePay\tIncomeTax\tNetPay");

                    while(reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name=reader.GetString(1);
                        int salary=reader.GetInt32(2);
                        DateTime startdate = Convert.ToDateTime(reader["startdate"]);
                        string gender=reader.GetString(3);
                        long phonenumber=reader.GetInt64(4);
                        string address=reader.GetString(5);
                        string department=reader.GetString(6);
                        int BasicPay=reader.GetInt32(7);
                        int Deduction=reader.GetInt32(8);
                        int TaxablePay=reader.GetInt32(9);
                        int IncomeTax=reader.GetInt32(10);
                        int NetPay=reader.GetInt32(11);

                        Console.WriteLine($"{id}\t{name}\t{salary}\t{startdate}\t{gender}" +
                            $"\t{phonenumber}\t{address}\t{department}\t{BasicPay}\t{Deduction}\t{TaxablePay}" +
                            $"\t{IncomeTax}\t{NetPay}");
                    }
                }
                else
                {
                    Console.WriteLine("No records found in the employeePayroll table.");
                }
                reader.Close();
                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
