using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Software
{
    class Admin : Staff
    {
        //fields
        private double overtimeRate = 15.5f;
        private const double adminHourlyRate = 30f;

        //properties

        public double Overtime { get; set;}

        //Constructor

        public Admin(string Name):base(Name,adminHourlyRate)
        {

        }

        //method

        public override void CaculatePay()
        {
            base.CaculatePay();

            if (HWorked > 160)
                Overtime = Overtime * (HWorked - 160);
        }

        public override string ToString()
        {
            return $"Name of staff = {NameOfStaff}\n Overtime = {Overtime}\n Admin Hourly = {adminHourlyRate}\n Total pay = {TotalPay}\n Basic Pay = {BasicPay}";
        }
    }
}
