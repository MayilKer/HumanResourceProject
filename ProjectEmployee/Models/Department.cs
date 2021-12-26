using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEmployee
{
    class Department
    {
        
        public string Name { get; set; }

        public int WorkerLimit { get; set; }
        public double SlaryLimit { get; set; }
        public Employee[] Employees { get; set; }
        public double AverageSalary { get; set; }


        public Department(string name,int workerLimit,double salarylimit)
        {
            WorkerLimit = workerLimit;
            SlaryLimit = salarylimit;
            Name = name;
            
        }
        
        public void CalcSalaryAverage(Employee[] employees)
        {
            
            Employees = employees;
            
           
            foreach (Employee employee in employees)
            {


                AverageSalary += employee.Salary / Employee.employeeCount;
            }
            
        }
        
        
        public override string ToString()
        {
            return $"Depatment: {Name} Worker \nLimit: {WorkerLimit} \nSalary limit: {SlaryLimit}";
        }
    }
}
