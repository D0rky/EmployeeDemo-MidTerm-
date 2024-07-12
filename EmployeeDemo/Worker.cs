using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo
{
    class Worker : Employee
    {
        public int YearWorked { get; private set; }
        protected int CurrentYear; 

        public Worker(string firstName, string lastName, string workID, int yearStartedWked, double initSalary, int currentYear)
            : base(firstName, lastName, workID, yearStartedWked, initSalary)
        {
            CurrentYear = currentYear;
            CalcYearWorked();
        }

        public void CalcYearWorked()
        {
            YearWorked = CurrentYear - YearStartedWked;
        }

        public override void CalcCurSalary()
        {
            double yearlyIncrement = InitSalary * 0.03;
            CurSalary = InitSalary + (YearWorked * yearlyIncrement);
        }
    }
}
