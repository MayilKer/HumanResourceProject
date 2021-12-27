using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEmployee.Interface
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get;}
        public Employee[] Employees { get; }
        void AddDepartment(string name, int workerLimit, double salarylimit);
        void EditDepartment(string DepartmentName,string NewDepartmentName, int workerLimit, double salarylimit);
        void AddEmployee(string fullname, double salary, string departamentname, string position);
        void RemoveEmployee(string EmployeNo, string DepNo);
        void EditEmployee(string EmployeNo,double salary,string position);
       Employee[] GetEmployeeListByDepartment(string DepName);
    }
}
