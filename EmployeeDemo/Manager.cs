using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo
{
    class Manager : Worker
    {
        public int YearPromo { get; set; }

        public Manager(string firstName, string lastName, string workID, int yearStartedWked, double initSalary, int currentYear, int yearPromo)
            : base(firstName, lastName, workID, yearStartedWked, initSalary, currentYear)
        {
            YearPromo = yearPromo;
        }

        public override void CalcCurSalary()
        {
            double yearlyIncrement;

            if (CurrentYear <= YearPromo)
            {
                yearlyIncrement = InitSalary * 0.03;
            }
            else
            {
                yearlyIncrement = InitSalary * 0.05 + InitSalary * 0.1;
            }

            CurSalary = InitSalary + (YearWorked * yearlyIncrement);
        }
    }
}
