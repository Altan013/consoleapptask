using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Models
{
    class Employee
    {
        private static int Count = 1000;
        public string No { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string DepartamentName { get; set; }

        public Employee(string position, string fullname, double salary, string departamentName)
        {
            FullName = fullname;
            Position = position;
            Salary = salary;
            DepartamentName = departamentName;
        }
        public override string ToString()
        {
            return $"{FullName} {Position} {Salary} {DepartamentName}";
        }
    }
}
