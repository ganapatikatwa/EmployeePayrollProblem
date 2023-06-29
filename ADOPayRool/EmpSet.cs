using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOPayRool
{
    public class EmpSet
    {
        public int id { get; set; }
        public string name { get; set; }
        public int salary { get; set;}
        public DateTime startdate { get; set; }
        public string gender { get; set; }
        public long phonenumber { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public int BasicPay { get; set; }
        public int Deduction { get; set; }
        public int TaxablePay { get; set; }
        public int IncomeTax { get; set; }
        public int NetPay { get; set; }

    }
}
