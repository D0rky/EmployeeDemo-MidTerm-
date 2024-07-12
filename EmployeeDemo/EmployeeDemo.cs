using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeeDemo
{
    class EmployeeDemo
    {
        static Employee[] employees;

        static void Main(string[] args)
        {
            ReadData();
            ObjSort();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEmployee Management Menu:");
                Console.WriteLine("1. Display Employees in Salary Range");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice (1/2): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayEmployeesInSalaryRange();
                            break;
                        case 2:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        static void ReadData()
        {
            string[] workerLines = File.ReadAllLines("worker.txt");
            string[] managerLines = File.ReadAllLines("manager.txt");

            int numWorkers = int.Parse(workerLines[0]);
            int numManagers = int.Parse(managerLines[0]);

            employees = new Employee[numWorkers + numManagers];
            int workerIndex = 1;
            int managerIndex = 1;

            if (int.TryParse(GetValidInput("Enter the current year: "), out int currentYear))
            {
                for (int i = 0; i < numWorkers; i++)
                {
                    string firstName = workerLines[workerIndex++];
                    string lastName = workerLines[workerIndex++];
                    string workID = workerLines[workerIndex++];
                    int yearStartedWked = int.Parse(workerLines[workerIndex++]);
                    double initSalary = double.Parse(workerLines[workerIndex++]);

                    employees[i] = new Worker(firstName, lastName, workID, yearStartedWked, initSalary, currentYear);
                }

                for (int i = numWorkers; i < numWorkers + numManagers; i++)
                {
                    string firstName = managerLines[managerIndex++];
                    string lastName = managerLines[managerIndex++];
                    string workID = managerLines[managerIndex++];
                    int yearStartedWked = int.Parse(managerLines[managerIndex++]);
                    double initSalary = double.Parse(managerLines[managerIndex++]);
                    int yearPromo = int.Parse(managerLines[managerIndex++]);

                    employees[i] = new Manager(firstName, lastName, workID, yearStartedWked, initSalary, currentYear, yearPromo);
                }
            }
            else
            {
                Console.WriteLine("Invalid input for the current year.");
            }
        }

        static void ObjSort()
        {
            Array.Sort(employees, (a, b) => b.CurSalary.CompareTo(a.CurSalary));
        }

        static void DisplayEmployeesInSalaryRange()
        {
            Console.Write("Enter the minimum current salary: ");
            if (double.TryParse(Console.ReadLine(), out double minSalary))
            {
                Console.Write("Enter the maximum current salary: ");
                if (double.TryParse(Console.ReadLine(), out double maxSalary))
                {
                    Console.WriteLine("Employees with current salary in the specified range:");

                    bool employeesFound = false;

                    foreach (var employee in employees)
                    {
                        if (employee.CurSalary >= minSalary && employee.CurSalary <= maxSalary)
                        {
                            if (employee is Worker worker)
                            {
                                Console.WriteLine($"{worker.FirstName} {worker.LastName}, WorkID: {worker.WorkID}, Current Salary: {worker.CurSalary:F2}");
                            }
                            else if (employee is Manager manager)
                            {
                                Console.WriteLine($"{manager.FirstName} {manager.LastName}, WorkID: {manager.WorkID}, Current Salary: {manager.CurSalary:F2}");
                            }

                            employeesFound = true;
                        }
                    }

                    if (!employeesFound)
                    {
                        Console.WriteLine("No employees found in the specified salary range.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for maximum salary. Please enter a valid salary value.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for minimum salary. Please enter a valid salary value.");
            }
        }

        static string GetValidInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }
    }
}
