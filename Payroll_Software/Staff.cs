using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Software
{
    class Staff
    {
        //fields
        private double hourlyRate;
        private int hWorked;

        //Properties
        public double TotalPay { get; set; }
        public double BasicPay { get; set; }
        public string NameOfStaff { get; set; }

        private int Allowance { get; set; }
        public int HWorked 
        { get => hWorked;
            set 
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }

        //Constructor

        public Staff()
        {

        }
        public Staff(string Name, double rate)
        {
            NameOfStaff = Name;
            hourlyRate = rate;
        }

        //Method

        public virtual void CaculatePay()
        {
            //caculated base on (day * work)
            Console.WriteLine("Caculating staff....");
            BasicPay = hourlyRate * hWorked;
            TotalPay = BasicPay;

        }

        public override string ToString()
        {
            return $"Name of staff = {NameOfStaff} \n Manager HourlyRate = {hourlyRate} \n Hour Worked = {HWorked}\n  Total Pay = {TotalPay} \n Basic Pay = {BasicPay}";
        }
    }
}
