using ConsoleProject.Models;
using System;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Developer", "Altan Ibrahimli", 10000,"IT");
            Employee emp2 = new Employee("Dizayner", "Metin Agayev", 3000, "DR");
            Employee emp3 = new Employee("Menecer", "Kamil Quliyev", 5500, "MN");
            Employee emp4 = new Employee("Marketing", "Rauf Abdullayev", 3000, "MR");
            Employee emp5 = new Employee("Muhasib", "Ramin Abbasov", 2500, "MH" );
           
            Employee[] Employees = { emp1, emp2, emp3, emp4, emp5 };

            Department dep1 = new Department(Employees, 6000, "ItDepartament", 20 ); ;
        }
    }
}
