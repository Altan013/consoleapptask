using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Interfaces
{
    interface IHumanResourceManager
    {
        Employee [] Employees { get; }
        Department [] Departments { get; }
        void AddDepartament(Employee[] employee, double SalaryLimit, string name, int WorkerLimit);
        Department[] GetDepartments(Department[] departments);
        void EditDepartaments(string Name, string NewName);
        void AddEmployee(string position, string fullname, double salary, string departamentName);
        void RemoveEmployee(string No, string DepartamentName);
        void EditEmployee(string No, string FullName, double Salary, string Position);



    }
}
