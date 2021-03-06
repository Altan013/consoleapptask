using ConsoleProject.Interfaces;
using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Employee[] Employees => _employee;
        private Employee[] _employee;

        public Department[] Departments => _departament;
        private Department[] _departament;
        public HumanResourceManager()
        {
            _employee = new Employee[0];
            _departament = new Department[0];

        }

        public void AddEmployee(string position, string fullname, double salary, string departamentName)
        {
            Employee employee = new Employee(position, fullname, salary, departamentName);
            Array.Resize(ref _employee, _employee.Length + 1);
            _employee[_employee.Length - 1] = employee;
        }

        public void EditDepartaments(string Name, string NewName)
        {
            Department department = null;
            foreach(Department item in _departament)
            {
                if (item.Name==Name)
                {
                    Name = NewName;
                    break;
                }
            }
        }

        public void EditEmployee(string No, string FullName, double Salary, string Position)
        {
            foreach (Employee item in _employee)
            {
                
                
            }
        }

        public Department[] GetDepartments(Department[] departments)
        {
           
        }

        public void RemoveEmployee(string No, string DepartamentName)
        {
            foreach (var item in _employee)
            {
                if(item.No==No)
                {
                   
                }
            }
        }

        public void AddDepartament(Employee[] employee, double SalaryLimit, string name, int WorkerLimit)
        {
            Department department = new Department(employee, SalaryLimit, name, WorkerLimit);
            Array.Resize(ref _departament, _departament.Length + 1);
            _departament[_departament.Length - 1] = department;
        }
    }
}
