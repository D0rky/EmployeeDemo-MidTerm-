using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo
{
    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WorkID { get; }
        public int YearStartedWked { get; set; }
        public double InitSalary { get; set; }
        public double CurSalary { get; protected set; }

        public Employee(string firstName, string lastName, string workID, int yearStartedWked, double initSalary)
        {
            FirstName = firstName;
            LastName = lastName;
            WorkID = workID;
            YearStartedWked = yearStartedWked;
            InitSalary = initSalary;
            CalcCurSalary();
        }

        public virtual void CalcCurSalary()
        {
            CurSalary = InitSalary;
        }
    }
}

