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
                        EmployeeOperations(ref humanResourceManager);
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
            static void EmployeeOperations(ref HumanResourceManager humanResourceManager)
            {
                do
                {

                    Console.WriteLine("-------------------------Employee Managment---------------------------");
                    Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                    Console.WriteLine("1 - Isci elave etmek:");
                    Console.WriteLine("2 - Iscilerin siyahisini gostermek:");
                    Console.WriteLine("3 - Departamentdeki iscilerin siyahisini gostermrek:");
                    Console.WriteLine("4 - Isci uzerinde deyisiklik etmek:");
                    Console.WriteLine("5 - Departamentden isci silinmesi :");
                    Console.WriteLine("6 - Esas menyuya qayidis :");
                    Console.Write("Daxil Et:");
                    string choose = Console.ReadLine();
                    int choosenum;
                    int.TryParse(choose, out choosenum);
                    switch (choosenum)
                    {
                        case 1:
                            Console.Clear();
                            AddEmployee(ref humanResourceManager);
                            break;
                        case 2:
                            Console.Clear();
                            GetEmployeeList(ref humanResourceManager);
                            break;
                        case 3:
                            Console.Clear();
                            GetEmployeeListByDepartment(ref humanResourceManager);
                            break;
                        case 4:
                            Console.Clear();
                            EditEmployee(ref humanResourceManager);
                            break;
                        case 5:
                            Console.Clear();
                            RemoveEmployee(ref humanResourceManager);
                            break;
                        case 6:
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
                    if (item == null)
                    {
                        return;
                    }
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
                    if (item == null)
                    {
                        return;
                    }
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
                int word;
                bool res1 = true;
                int check = 0;
                while (res1)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == NewDepName.ToLower())
                        {
                            check++;
                        }
                    }
                    if (check > 0)
                    {
                        Console.WriteLine("Daxil etiyinizz ad movcudur");
                        NewDepName = Console.ReadLine();
                    }
                    else if(int.TryParse(NewDepName,out word))
                    {
                        Console.WriteLine("Reqem daxil ede bilmersiz");
                        goto again;
                    }
                    else
                    {
                        res1 = false;
                    }
                    check = 0;
                }
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
            static void AddEmployee(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.WriteLine("Once Department yaradmalisiz");
                    return;
                }
                check2:
                Console.WriteLine("Employee-nin Adini ve Soyadini daxil edin");
                string FullName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(FullName))
                {
                    Console.WriteLine("Bos ola bilmez");
                    Console.WriteLine("Duzgun daxil edin");
                    FullName = Console.ReadLine();
                    goto check2;
                }
                start2:
                Console.WriteLine("Iscinin mawini daxil edin");
                string salary = Console.ReadLine();
                double salaryNum;
                while(!double.TryParse(salary, out salaryNum) || salaryNum <= 0)
                {
                    Console.WriteLine("Duzgun mas Daxil Et:");
                    salary = Console.ReadLine();
                }
                if (salaryNum < 250)
                {
                    Console.WriteLine("Iscinin maasi 250-den asagi ola bilmez");
                    goto start2;
                }
                Console.WriteLine("Movcud olan Departamentinin adini daxil edin");
                foreach (Department item in humanResourceManager.Departments)
                {
                    Console.WriteLine(item.Name);
                }
                string departmen = Console.ReadLine();
                int count = 0;
                bool res = true;
                while (res)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        if (item.Name.ToLower() == departmen.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        res = false;
                    }
                    else
                    {
                        Console.WriteLine("Daxil etdiyiniz Department ad movcud deil");
                        Console.WriteLine("Yeniden daxil edin");
                        departmen = Console.ReadLine();
                    }
                    count = 0;
                }
                Console.WriteLine("Position daxil edin");
                string position = Console.ReadLine();
                humanResourceManager.AddEmployee(FullName,salaryNum,departmen,position);
            }
            static void GetEmployeeList(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Employees.Length <= 0)
                {
                    Console.WriteLine("Department list bowdu");
                    return;
                }
                foreach (Employee item in humanResourceManager.Employees)
                {
                    if (item != null)
                    {
                        Console.WriteLine("--------------------------------");
                    Console.WriteLine(item);
                    }
                    
                }
                
            }
            static void GetEmployeeListByDepartment(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Departments.Length <= 0)
                {
                    Console.WriteLine("Departament siahisi bosdu");
                    Console.WriteLine("Onceden yeni Department yaradin");
                    return;
                }
                if (humanResourceManager.Employees.Length <= 0)
                {
                    Console.WriteLine("Employee siahisi bosdu");
                    Console.WriteLine("Onceden Departamente isci Elave edin");
                }
                
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item == null)
                    {
                        return;
                    }
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("Isteyiviz Departamentin iwcilerinin siahisini elde etmek ucun movcud Departamentin adini daxil edin");
                string EmpByDep = Console.ReadLine();
                int count = 0;
                bool res = true;
                while (res)
                {
                    foreach (Employee item in humanResourceManager.Employees)
                    {
                        if (item != null && item.DepartamnetName.ToLower() == EmpByDep.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        res = false;
                    }
                    else
                    {
                        Console.WriteLine("Departament adi sefdir");
                        Console.WriteLine("Yeniden daxil edin");
                        EmpByDep = Console.ReadLine();
                    }
                    count = 0;
                }
                Console.Clear();
                Employee[] employee = humanResourceManager.GetEmployeeListByDepartment(EmpByDep);
                
                if (employee.Length <= 0)
                {
                    Console.WriteLine("Daxil etdiyiviz Departament bowdur");
                    return;
                }
                foreach (Employee item in employee)
                {
                    if (item != null)
                    {

                        Console.WriteLine("--------------------");
                        Console.WriteLine(item);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            static void EditEmployee(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Employees.Length <= 0)
                {
                    Console.WriteLine("Employee siyahisii bowdur");
                }
                foreach (Employee item in humanResourceManager.Employees)
                {
                    if (item != null)
                    {
                       Console.WriteLine("--------------------------------");
                    Console.WriteLine(item);
                    }
                    
                }
                Console.WriteLine("Duzeliw elemey iwcinin NO-ni daxil edin");
                string No = Console.ReadLine();
                bool res = true;
                int check = 0;
                while (res)
                {
                    foreach (Employee item in humanResourceManager.Employees)
                    {
                        if (item != null && item.No.ToLower() == No)
                        {
                            Console.Clear();
                            Console.WriteLine(item);
                            check++;
                        }
                    }
                    if (check < 0)
                    {
                        Console.WriteLine("Daxil etdiyiniz NO-re movcud deil");
                        return;
                    }
                    else
                    {
                        res = false;
                        
                    }
                    check = 0;

                }
                Console.WriteLine("Yeni masini daxil edin");
                goo:
                string newsalary = Console.ReadLine();
                double newsalaryNum;
                while (!double.TryParse(newsalary,out newsalaryNum) || newsalaryNum <= 0)
                {
                    Console.WriteLine("Duzgun mas daxil edin");
                    newsalary = Console.ReadLine();
                }
                if (newsalaryNum < 250)
                {
                    Console.WriteLine("Employee-nin masi 250-den asagi ola bilmez");
                    Console.WriteLine("Yeniden daxil edin");
                    goto goo;
                }
                Console.WriteLine("Yeni position daxil edin");
                yes:
                string newPos = Console.ReadLine();
                double check2;
                if (double.TryParse(newPos, out check2))
                {
                    Console.WriteLine("Position reqem ola bilmez");
                    Console.WriteLine("Yeniden daxil edin");
                    goto yes;
                }
                humanResourceManager.EditEmployee(No, newsalaryNum, newPos);
            }
            static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
            {
                if (humanResourceManager.Employees.Length <= 0)
                {
                    Console.WriteLine("Employee siahisi bowdur");
                    return;
                }
                foreach (Employee item in humanResourceManager.Employees)
                {
                    if (item != null)
                    {
                        Console.WriteLine("--------------------------");
                    Console.WriteLine(item);
                    }
                    
                }
                Console.WriteLine("Silmey istediyiviz iscinin Departament adini ve NO-ni daxil edin");
                ready:
                Console.Write("Departament: ");
                string Dep = Console.ReadLine();
                Console.WriteLine();
                Console.Write("NO: ");
                string No = Console.ReadLine();
                bool res = true;
                int count = 0;
                while (res)
                {
                    foreach (Employee item in humanResourceManager.Employees)
                    {
                        if (item != null && item.DepartamnetName.ToLower() == Dep.ToLower() && item.No.ToLower() == No.ToLower())
                        {
                            count++;
                        }
                    }
                    if (count <= 0)
                    {
                        Console.WriteLine("Daxil etiyinizz Departament ve Nomre sefdir");
                        Console.WriteLine("Yeniden daxil edin");
                        goto ready;
                    }
                    else
                    {
                        res = false;
                    }
                    count = 0;
                }
                humanResourceManager.RemoveEmployee(No, Dep);
            }
        }

    }
}
