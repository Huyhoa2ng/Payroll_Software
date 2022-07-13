using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Software
{
    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear { Jan = 1 , FEB = 2, APR, MAY, JUNE, JULY ,AUGUST, SEPTEMBER,OCTOBER,NOVEMBER,DECEMBER};

        public PaySlip(int monthPay,int yearsPay)
        {
            month = monthPay;
            year = yearsPay;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            foreach(Staff f in myStaff)
            {
                path = f.NameOfStaff + "txt";
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path))
                {
                    sw.WriteLine($"Pay slip for {month} {year} ");
                    sw.WriteLine("=========================");
                    sw.WriteLine($"Name of staff: {f.NameOfStaff}");
                    sw.WriteLine($"Hours Worked: {f.HWorked}");
                    sw.WriteLine($"");
                    sw.WriteLine($"Basic Pay : {f.BasicPay:C}");
                    if (f.GetType() == typeof(Admin))
                        sw.WriteLine($"Allowance: {0:C}",((Admin)f).Overtime);

                    sw.WriteLine("");
                    sw.WriteLine("====================");
                    sw.WriteLine($"Total pay: {f.TotalPay:C}");
                    sw.WriteLine("====================");
                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result = from f in myStaff where f.HWorked < 10 orderby f.NameOfStaff ascending select new { f.NameOfStaff, f.HWorked };

            string path = "summary.txt";

            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours ");
                sw.WriteLine("");
                foreach(var f in result)
                {
                    sw.WriteLine($"Name of staff: {f.NameOfStaff}, Hours Worked: {f.HWorked}");
                    sw.Close();
                }
            }
        }
        public override string ToString()
        {
            return $"Month: {month} , Year: {year}";
        }
    }
}
