using ConsoleProject.Models;
using ConsoleProject.Services;
using System;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager HumanResourceManager = new HumanResourceManager();

            do

            {
                Console.WriteLine("--------------------------------IHumanResourceManager-------------------------------");
                Console.WriteLine("Etmek istediyiniz emeliyyatin qarshisindaki reqemi daxil edin");
                Console.WriteLine("1.1 - Departamentlerin siyahisini gostermek");
                Console.WriteLine("1.2 - Departament yaratmaq");
                Console.WriteLine("1.3 - Departamentde deyishiklik etmek");
                Console.WriteLine("2.1 - Ishcilerin siyahisini gostermek");
                Console.WriteLine("2.2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("2.3 - Isci elave etmek");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departamentden isci silinmesi");

                string choose = Console.ReadLine();
                double chooseNum;
                double.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1.1:
                        GetDepartment(ref HumanResourceManager);
                        Console.Clear();
                        break;
                    case 1.2:
                        AddDepartment(ref HumanResourceManager);
                        Console.Clear();
                        break;
                    case 1.3:
                        EditDepartment(ref HumanResourceManager);
                        Console.Clear();
                        break;
                    case 1.4:
                        SearchEmployee(HumanResourceManager);
                        break;
                    case 2.1:
                        GetDepartment(ref HumanResourceManager);
                        Console.Clear();
                        break;
                    case 2.2:
                        GetDepartment(ref HumanResourceManager);
                        Console.Clear();
                        break;
                    case 2.3:
                        AddEmployee(HumanResourceManager);
                        Console.Clear();
                        break;
                    case 2.4:
                        EditEmployee(HumanResourceManager);
                        Console.Clear();
                        break;
                    case 2.5:
                        RemoveEmployee(HumanResourceManager);
                        Console.Clear();
                        break;
                    

                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun daxil et");
                        break;
                }

            } while (true);

            static void AddDepartment(ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("Departmentin adini daxil et");
                string name = Console.ReadLine();
                Console.WriteLine("Isci sayini daxil et");
                string WorkerLimit = Console.ReadLine();
                int WorkerLimitNum = 0;
                while (!int.TryParse(WorkerLimit, out WorkerLimitNum) || WorkerLimitNum <= 0)

                {
                    Console.WriteLine("Duzgun daxil et");
                    WorkerLimit = Console.ReadLine();
                }

                Console.WriteLine("SalaryLimiti daxil et");
                string salaryLimit = Console.ReadLine();
                double salaryLimitNum = 0;
                while (!double.TryParse(salaryLimit, out salaryLimitNum) || salaryLimitNum <= 249)
                {
                    Console.WriteLine("Duzgun daxil et");
                    salaryLimit = Console.ReadLine();
                }





            }
            static void GetDepartment(ref HumanResourceManager humanResourceManager)
            {

                if (humanResourceManager.Departments.Length > 0)
                {
                    foreach (var item in humanResourceManager.Departments)
                    {
                        Console.WriteLine($"{item} - Maas ortalamasi: {item.CalcAverageSalary(item)}\n");
                    }
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Sistemde Department Movcud deyil\n");


                }
            }
            static void EditDepartment(ref HumanResourceManager humanResourceManager)
            {
                GetDepartment(ref humanResourceManager);
                if (humanResourceManager.Departments.Length > 0)
                {
                    string name;
                    bool check = true;
                    do
                    {
                        if (check)
                        {
                            Console.WriteLine("Deyisiklik edeceyiniz departmenti daxil edin");
                        }
                        else
                        {
                            Console.WriteLine("Departmentin adini duzgun qebul edin");
                        }
                        name = Console.ReadLine();
                        check = false;

                    } while (humanResourceManager.CheckName(name));
                    do
                    {
                        if (check)
                        {
                            Console.WriteLine("Daxil edilen department duzgun deyil");
                            name = Console.ReadLine();
                        }
                        check = true;

                    } while (humanResourceManager.FindDepartment(name) == null);



                }

            }
        }

        static void SearchEmployee(HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                string search;

                do
                {
                    Console.WriteLine("Axtaris deyerini daxil edin:");
                    search = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(search));

                var searchedEmployees = humanResourceManager.SearchEmployee(search);

                if (searchedEmployees.Length > 0)
                {
                    Console.WriteLine("Axtarisa uygun isciler: \n");
                    foreach (var item in searchedEmployees)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("====================================================\n");
                    Console.WriteLine("Axtarisa uygun isci tapilmadi!");
                }
            }
            else
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hecbir department ve isci movcud deyil");
            }

        }

        static void RemoveEmployee(HumanResourceManager humanResourceManager)
        {

            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hec bir department ve isci movcud deyil");
            }
            else
            {
                string departmentname;
                Department department = null;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Silmek istediyiniz iscinin departmentini daxil edin:");
                    else
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");

                    departmentname = Console.ReadLine();
                    department = humanResourceManager.FindDepartmentByName(departmentname);
                    check = false;

                } while (department == null);

                if (department.Employees.Length <= 0)
                {
                    Console.WriteLine("====================================================\n");
                    Console.WriteLine("Daxil etdiyiniz departmentde hecbir isci movcud deyil");
                    return;
                }
                else
                {
                    string no;
                    check = true;
                    do
                    {
                        if (check)
                            Console.WriteLine("Silmek istediyiniz iscinin nomresini daxil edin:");
                        else
                            Console.WriteLine("Daxil etdiyiniz nomre yanlisdir, yeniden daxil edin");

                        no = Console.ReadLine();
                        check = false;

                        foreach (var item in department.Employees)
                        {
                            if (item.No == no)
                            {
                                check = true;

                            }


                        }

                    } while (check == false);

                    humanResourceManager.RemoveEmployee(no, departmentname);
                }


            }
        }

        static void EditEmployee(HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hec bir department ve isci movcud deyil");
            }
            else
            {
                string departmentname;
                Department department = null;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Deyisdirmek istediyiniz iscinin departmentini daxil edin:");
                    else
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");

                    departmentname = Console.ReadLine();
                    department = humanResourceManager.FindDepartmentByName(departmentname);
                    check = false;

                } while (department == null);

                if (department.Employees.Length <= 0)
                {
                    Console.WriteLine("====================================================\n");
                    Console.WriteLine("Daxil etdiyiniz departmentde hecbir isci movcud deyil");
                    return;
                }
                else
                {
                    string no;
                    check = true;
                    do
                    {
                        if (check)
                            Console.WriteLine("Iscinin nomresini daxil edin:");
                        else
                            Console.WriteLine("Daxil etdiyiniz nomre yanlisdir, yeniden daxil edin");

                        no = Console.ReadLine();
                        check = false;

                        foreach (var item in department.Employees)
                        {
                            if (item.No == no)
                            {
                                Console.WriteLine($"Iscinin tam adi: {item.FullName} - Iscinin vezifesi: {item.Position} - Iscinin maasi: {item.Salary} ");
                                check = true;

                            }


                        }


                    } while (check == false);

                    string position;
                    check = true;
                    do
                    {
                        if (check)
                            Console.WriteLine("Iscinin yeni vezifesini daxil edin:");
                        else
                            Console.WriteLine("Vezife adinda reqem olmamalidir, yeniden daxil edin");

                        position = Console.ReadLine();
                        check = false;

                    } while (!humanResourceManager.CheckName(position));

                    double salary;
                    string salarystr;
                    check = true;
                    do
                    {

                        if (check)
                            Console.WriteLine("Iscinin yeni maasini daxil edin:");
                        else
                            Console.WriteLine("Maas yazarken herf olmamalidir ve maas 250den asagi olmamalidir, yeniden daxil edin");

                        salarystr = Console.ReadLine();
                        check = false;

                    } while (!double.TryParse(salarystr, out salary) || salary < 250);

                    humanResourceManager.EditEmployee(departmentname, no, position, salary);

                }

            }

        }

        static void AddEmployee(HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Sistemde hec bir department movcud deyil");
            }
            else
            {
                string departmentname;
                Department department = null;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Isci elave etmek istediyiniz departmenti daxil edin:");
                    else
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");

                    departmentname = Console.ReadLine();
                    department = humanResourceManager.FindDepartmentByName(departmentname);
                    check = false;

                } while (department == null);

                if (department.WorkerLimit <= department.Employees.Length)
                {
                    Console.WriteLine("Departmentin isci limiti doludur, isci elave ede bilmezsiniz!");

                    return;
                }

                string fullname;
                check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Iscinin tam adini (ad, soyad seklinde) daxil edin:");
                    else
                        Console.WriteLine("Tam adi duzgun daxil edin");

                    fullname = Console.ReadLine();
                    check = false;

                } while (!humanResourceManager.CheckFullName(fullname));

                string position;
                check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Iscinin vezifesini daxil edin:");
                    else
                        Console.WriteLine("Vezife adi boyuk herfnen baslamali ve reqem olmamalidir, yeniden daxil edin");

                    position = Console.ReadLine();
                    check = false;

                } while (!humanResourceManager.CheckName(position));

                double salary;
                string salarystr;
                check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Iscinin maasini daxil edin:");
                    else
                        Console.WriteLine("Maas yazarken herf olmamalidir ve maas 250den asagi olmamalidir, yeniden daxil edin");

                    salarystr = Console.ReadLine();
                    check = false;

                } while (!double.TryParse(salarystr, out salary) || salary < 250);

                if (department.TotalSalary(department) + salary > department.SalaryLimit)
                {
                    Console.WriteLine("Elave etmek istediyiniz iscinin maasi toplam limitten artiqdir");
                    return;
                }

                humanResourceManager.AddEmployee(departmentname, fullname, position, salary);
            }


        }

    }
}
