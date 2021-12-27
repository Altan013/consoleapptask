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
        
        public void EditEmployee(string departmentname, string no, string position, double salary)
        {
            Department department = FindDepartmentByName(departmentname);

            if (department == null) return;

            foreach (var item in department.Employees)
            {
                if (item.No == no)
                {
                    if (department.TotalSalary(department) - item.Salary + salary < department.SalaryLimit)
                    {
                        item.Position = position;
                        item.Salary = salary;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Yeni daxil etdiyiniz maas departmentin maas limitinden artiqdir");
                    }
                }

            }


        }

        public void GetDepartments()
        {
            if (Departments.Length > 0)
            {
                foreach (var item in Departments)
                {
                    Console.WriteLine($"Departamentin adi: {item.Name} - Isci limiti: {item.WorkerLimit} -  Maas limiti: {item.SalaryLimit} ");
                }
            }
            else
            {
                Console.WriteLine("Sistemde hecbir department yoxdur");
            }

        }


        public void RemoveEmployee(string no, string departmentname)
        {
            Department department = FindDepartmentByName(departmentname);

            if (department == null)
            {
                Console.WriteLine("Bele adla sistemde department yoxdur");
            }
            else
            {
                Employee[] employees = new Employee[0];
                foreach (var item in department.Employees)
                {
                    if (item.No != no)
                    {
                        Array.Resize(ref employees, employees.Length + 1);
                        employees[employees.Length - 1] = item;
                        department.Employees = employees;

                    }
                }

            }

        }

        public void AddDepartment(string name, int workerlimit, double salarylimit, object[] _departments)
        {

            Department department = FindDepartmentByName(name);

            if (department == null)
            {
                department = new Department(name, workerlimit, salarylimit);
                Array.Resize(ref _departments, Departments.Length + 1);
                Departments[Departments.Length - 1] = department;

            }

        }

        public Department FindDepartment(string name)
        {
            foreach (var item in Departments)
            {
                if (item.Name == name)
                {
                    return item;

                }
            }
            return null;
        }

        public bool CheckName(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (str.Length > 1)
                {
                    if (Char.IsUpper(str[0]))
                    {
                        foreach (var chr in str)
                        {
                            if (Char.IsLetter(chr) == false)
                            {
                                return false;

                            }
                        }
                        return true;
                    }

                }
            }

            return false;
        }

        public Department FindDepartmentByName(string name)
        {
            foreach (var item in Departments)
            {
                if (item.Name == name)
                {
                    return item;

                }
            }
            return null;
        }

        public void EditDepartments(string Name, string NewName)
        
            {
                if (FindDepartmentByName(NewName) != null) return;

                {
                    Department existDepartment = FindDepartmentByName(Name);

                    if (existDepartment != null)
                    {
                        existDepartment.Name = NewName;
                        foreach (var item in existDepartment.Employees)
                        {
                            item.DepartamentName = NewName;
                        }
                    }

                }
            }



            public Employee[] SearchEmployee(string search)
        {
            {
                Employee[] employees = new Employee[0];
                foreach (var department in Departments)
                {
                    foreach (var item in department.Employees)
                    {
                        if ((item.FullName).Contains(search))
                        {

                            Array.Resize(ref employees, employees.Length + 1);
                            employees[employees.Length - 1] = item;

                        }
                    }
                }
                return employees;
            }
        }

        public void AddEmployee(string DepartmentName, string FullName, string position, double salary)
        {
            Department department = FindDepartmentByName(DepartmentName);

            if (department == null)
            {
                Console.WriteLine("Sistemde bu adda department yoxdur");
            }
            else if (department.WorkerLimit <= department.Employees.Length)
            {
                Console.WriteLine("Departmentin isci limiti dolub. Isci elave ede bilmezsinizzz");
            }
            else if (department.TotalSalary(department) + salary > department.SalaryLimit)
            {
                Console.WriteLine("Elave etmek istediyiniz iscinin maasi toplam limitten artiqdir");

            }
            else
            {
                Employee employee = new Employee(DepartmentName)
                {
                    DepartamentName = DepartmentName,
                    FullName = FullName,
                    Position = position,
                    Salary = salary
                };
                

                Array.Resize(ref department.Employees, department.Employees.Length + 1);
                department.Employees[department.Employees.Length - 1] = employee;
            }

        }

        public Employee[] GetAllEmployees()
        {
            Employee[] employees = new Employee[0];

            if (Departments.Length < 1) return null;

            foreach (var item in Departments)
            {
                foreach (var emp in item.Employees)
                {
                    Array.Resize(ref employees, employees.Length + 1);
                    employees[employees.Length - 1] = emp;
                }
            }
            return employees;
        }

        public bool CheckFullName(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                var words = str.Split(" ");
                if (words.Length > 1)
                {
                    foreach (var word in words)
                    {
                        if (string.IsNullOrWhiteSpace(word))
                        {
                            return false;
                        }

                        foreach (var chr in word)
                        {
                            if (Char.IsLetter(chr) == false)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }

            return false;
        }

        public void AddDepartment(string name, int workerlimit, double salarylimit)
        {
            throw new NotImplementedException();
        }
    }
}
