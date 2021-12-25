using ConsoleProject.Models;
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
                        GetDepartment(ref humanResourceManager);

                        Console.Clear();


                        break;
                    case 1.2:
                        Console.Clear();
                        break;
                    case 1.3:
                        Console.Clear();
                        break;
                    case 2.1:
                        Console.Clear();
                        break;
                    case 2.2:
                        Console.Clear();
                        break;
                    case 2.3:
                        AddDepartment(ref humanResourceManager);
                        Console.Clear();
                        break;
                    case 2.4:
                        Console.Clear();
                        break;
                    case 2.5:
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

                if (humanResourceManager.departments.Length > 0)
                {
                    foreach (var item in humanResourceManager.departments)
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
                if (humanResourceManager.departments.Length > 0)
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

                    } while (humanResourceManager.FindDepartment(name)) == null;



                }

            }
        }

    }
}
