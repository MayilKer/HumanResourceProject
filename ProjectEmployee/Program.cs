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
                    Console.WriteLine("1 -Departamenet yaratmaq:");
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
                            AddDepartment(ref humanResourceManager);
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
            }
            static void AddDepartment(ref HumanResourceManager humanResourceManager)
            {

            }
        }
        
    }
}
