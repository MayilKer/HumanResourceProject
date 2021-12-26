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
        void EditDepartment(string DepartmentName,string NewDepartmentName);
        void AddEmployee(string fullname, double salary, string departamentname, string position);
        void RemoveEmployee(string EmployeNo);
        void EditEmployee(string EmployeNo, string fullname, double salary,string position);
    }
}
