using ProjectEmployee.Service;
using System;

namespace ProjectEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {

                Console.WriteLine("-------------------------HumanResource Managment---------------------------");
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                Console.WriteLine("1 - Departmen uzerinde emeliyyatlar:");
                Console.WriteLine("2 - Employee uzerinde emeliyyatlar:");
                Console.WriteLine("3 - Sistemden Cix:");
                Console.Write("Daxil Et:");
                string choose = Console.ReadLine();
                int choosenum;
                int.TryParse(choose, out choosenum);
                switch (choosenum)
                {
                    case 1:
                        Console.Clear();
                        DepartmentOperation(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzzgun daxil et");
                        break;
                }
            } while (true);

            static void DepartmentOperation(ref HumanResourceManager humanResourceManager)
            {
                do
                {

                    Console.WriteLine("-------------------------Department Managment---------------------------");
                    Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                    Console.WriteLine("1 - Departamenet yaratmaq:");
                    Console.WriteLine("2 - Departameantlerin siyahisini gostermek:");
                    Console.WriteLine("3 - Departmanetde deyisiklik etmek:");
                    Console.WriteLine("4 - Esas menyuya qayidis");
                    Console.Write("Daxil Et:");
                    string choose = Console.ReadLine();
                    int choosenum;
                    int.TryParse(choose, out choosenum);
                    switch (choosenum)
                    {
                        case 1:
                            Console.Clear();
                            AddDepartment(ref humanResourceManager);
                            break;
                        case 2:
                            Console.Clear();
                            GetDepartamentsList(ref humanResourceManager);
                            break;
                        case 3:
                            Console.Clear();
                            EditDepartment(ref humanResourceManager);
                            break;
                        case 4:
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Duzzgun daxil et");
                            break;
                    }
                } while (true);
            }
            static void AddDepartment(ref HumanResourceManager humanResourceManager)
            {
                Console.Write("Yeni Department adini daxil edin: ");
                string name = Console.ReadLine();
                int count = 0;
                bool res = true;
                while (res)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == name.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        Console.WriteLine("Ad movcuddur");
                        Console.WriteLine("Yeni department ad daxil edin");
                        name = Console.ReadLine();
                    }
                    else
                    {
                        res = false;
                    }

                    count = 0;
                }
            start:
                Console.Write("Departament mawi daxil edin: ");
                string salary = Console.ReadLine();
                double salaryNum;


                while (!double.TryParse(salary, out salaryNum) || salaryNum <= 0)
                {
                    Console.WriteLine("Duzgun mas Daxil Et:");
                    salary = Console.ReadLine();
                }
                if (salaryNum < 250)
                {
                    Console.WriteLine("Departament mawi 250-den asagi ola bilmez");
                    goto start;
                }
                Console.Write("Departamentin Worker sayini daxil edin: ");
                string worker = Console.ReadLine();
                int workeNum;
                while (!int.TryParse(worker, out workeNum) || workeNum <= 0)
                {
                    Console.WriteLine("Duzgun say daxil edin");
                    worker = Console.ReadLine();
                }
                humanResourceManager.AddDepartment(name, workeNum, salaryNum);
                
            }
            static void GetDepartamentsList(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.WriteLine("Department list bowdu");
                    return;
                }
                foreach (Department item in humanResourceManager.Departments)
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine(item);
                }
            }
            static void EditDepartment(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.WriteLine("Department list bowdu");
                    return;
                }
                foreach (Department item in humanResourceManager.Departments)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine(item);
                }
                Console.WriteLine("Deyiwilik etmek istediyiviz Departamentin adini daxil edin");
                string DepName = Console.ReadLine();
                bool res = true;
                int count = 0;
                while (res)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == DepName.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count<=0)
                    {
                        Console.WriteLine("Daxil etdiyiviz Departament adi sefdir");
                        Console.WriteLine("Yeniden daxil edin");
                        DepName = Console.ReadLine();
                    }
                    else
                    {
                        res = false;
                    }
                    count = 0;
                }
                again:
                Console.WriteLine("Yeni Departament adini daxil edin");
                string NewDepName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(NewDepName))
                {
                    Console.WriteLine("Bos ola bilmez");
                    Console.WriteLine("Duzgun daxil edin");
                    NewDepName = Console.ReadLine();
                    goto again;
                }
                Console.WriteLine("Teze worker limit sayini daxil edin");
                string workerlimit = Console.ReadLine();
                int workerlimitNum;
                while (!int.TryParse(workerlimit, out workerlimitNum) || workerlimitNum <= 0)
                {
                    Console.WriteLine("Duzgun Say Daxil Et:");
                    workerlimit = Console.ReadLine();
                }
                Console.WriteLine("Yeni Salary limiti daxil edin");
                string newSalaryLimit = Console.ReadLine();
                double newSalaryLimitNum;
                while (!double.TryParse(newSalaryLimit, out newSalaryLimitNum) || newSalaryLimitNum <= 0)
                {
                    Console.WriteLine("Duzgun reqem Daxil Et:");
                    newSalaryLimit = Console.ReadLine();
                }
                humanResourceManager.EditDepartment(DepName,NewDepName,workerlimitNum,newSalaryLimitNum);
            }
        }

    }
}
