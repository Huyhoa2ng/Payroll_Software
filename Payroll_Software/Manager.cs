using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Software
{
    class Manager : Staff
    {
        //fields
        private const double managerHourlyRate = 50;
        
        //Properties

        private int Allowance { get; set; }


        public Manager(string Name) : base(Name, managerHourlyRate)
        {

        }

        public override void CaculatePay()
        {
            base.CaculatePay();
            Allowance = 1000;
            //if someone who worked over 160 hours their allowance will be added 1000
            if (HWorked > 160)
                TotalPay = BasicPay + Allowance;
        }

        public override string ToString()
        {
            return $"Name of staff = {NameOfStaff} \n Manager HourlyRate = {managerHourlyRate} \n Hour Worked = {HWorked}\n Allowance = {Allowance} \n Total Pay = {TotalPay} \n Basic Pay = {BasicPay}";
        }
    }
}
