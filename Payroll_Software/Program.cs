using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Software
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> mystaff = new List<Staff>();
            FileReader fr = new FileReader();
            int month = 0, year = 0;
            while(year ==0)
            {
                Console.WriteLine("Please enter the year : ");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message + "Please try again!!!");
                }
            }

            while(month == 0)
            {
                Console.WriteLine("Please enter the month : ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if(month <1 || month >12)
                    {
                        Console.WriteLine("Month must be around 1 to 12 . Please try again!!!");
                        month = 0;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message + "Please try it again!!!");
                }
                mystaff = fr.ReadFile();

                for(int i = 0; i < mystaff.Count; i++)
                {
                    try
                    {
                        Console.WriteLine($"\nEnter hours worked for {mystaff[i].ToString()}");

                        mystaff[i].HWorked = Convert.ToInt32(Console.ReadLine());
                        mystaff[i].CaculatePay();
                        Console.WriteLine(mystaff[i].ToString());
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        i--;
                    }
                }
                PaySlip ps = new PaySlip(month,year);
                ps.GeneratePaySlip(mystaff);
                ps.GenerateSummary(mystaff);
                Console.ReadLine();
            }
        }   
    }
}
