using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEmployee
{
    class Employee
    {
        public static int employeeCount = 0;
       private static int count = 1000;
        public string No { get; set; }
        public string Fullname { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public string DepartamnetName { get; set; }

        public Employee(string fullname,double salary,string departamentname,string position)
        {
            employeeCount++;
            count++;
            Fullname = fullname;
            Salary = salary;
            DepartamnetName = departamentname;
            Position = position;
            for (int i = 0; i < 2; i++)
            {
                No += departamentname[i];
                
            }
            
            No += count;
            
        }
        public override string ToString()
        {
            return $"Full name: {Fullname} \nSalary: {Salary} \nNo: {No.ToUpper()} \nPosition: {Position} \nDepatmenName: {DepartamnetName}";
        }

    }
}
