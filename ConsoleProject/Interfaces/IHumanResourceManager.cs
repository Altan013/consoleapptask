using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Interfaces
{
    interface IHumanResourceManager
    {
        void AddDepartment(string name, int workerlimit, double salarylimit);
        void GetDepartments();
        void EditDepartments(string name, string newname);
        void AddEmployee(string departmentname, string fullname, string position, double salary);
        void EditEmployee(string departmentname, string no, string position, double salary);
        Employee[] SearchEmployee(string search);
        void RemoveEmployee(string no, string departmentname);
        Department FindDepartmentByName(string name);
        bool CheckName(string str);
    }
}
