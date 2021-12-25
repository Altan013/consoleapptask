using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Models
{
    class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; } 
        public Employee[] Employees { get; set; }
        
        public static int Count = 0;
        //public int CalcSalaryAverage();

        public Department(Employee[] employee, double salaryLimit, string name, int workerLimit)
        {
            //if (Employees.Length <= 0)
            //{
            //    Console.WriteLine("Ishci sayi minimum 1 ola biler");
            //    return;
            //}
            //if (SalaryLimit < 250)
            //{
            //    Console.WriteLine("Verilen maash 250-den az ola bilmez");
            //    return;
            //}
            //if (name.Length < 2)
            //{
            //    Console.WriteLine("Departament adi minimum 2 herfden ibaret olmalidir");
            //    return;
            //}

            Employees = employee;
            SalaryLimit = salaryLimit;
            Name = name;
            WorkerLimit = workerLimit;

        }
        public double CalcSalaryAverage(Department department)
        {
            double totalSalary = 0;
            Count++;
            foreach (Employee item in Employees)
            {
                totalSalary += item.Salary;
                Count++;
            }
            return totalSalary / Count;
        }
        //public override string ToString()
        //{
        //    return $"{Fullname} {Position} {Salary} {DepartmentName}"
        //}

    }
}
