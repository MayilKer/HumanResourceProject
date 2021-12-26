using System;
using System.Collections.Generic;
using System.Text;
using ProjectEmployee.Interface;

namespace ProjectEmployee.Service
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Department[] Departments => _departments;
        private Department[] _departments;


        public Employee[] Employees => _employees;

        private Employee[] _employees;
        public HumanResourceManager()
        {
            _employees = new Employee[0];
            _departments = new Department[0];
        }

        public void AddDepartment(string name, int workerLimit, double salarylimit)
        {
            Department department = new Department(name: name, workerLimit: workerLimit, salarylimit:salarylimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length-1] = department;
        }

        public void AddEmployee(string fullname, double salary, string departamentname, string position)
        {
            Employee employee = new Employee(fullname: fullname,salary:salary,departamentname:departamentname,position:position);
            Array.Resize(ref _employees, _employees.Length + 1);
            _employees[_employees.Length - 1] = employee;
        }

        public void EditDepartment(string DepartmentName, string NewDepartmentName,int workerLimit, double salarylimit)
        {
            Department departments = null;
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == DepartmentName.ToLower())
                {
                    departments = item;
                }
            }
            departments.Name = NewDepartmentName;
            departments.WorkerLimit = workerLimit;
            departments.SlaryLimit = salarylimit;
        }

        public void EditEmployee(string EmployeNo, string fullname, double salary, string position)
        {
            Employee employee = null;
            foreach (Employee item in _employees)
            {
                if (item != null && item.No.ToLower() == EmployeNo.ToLower())
                {
                    employee = item;
                }
            }
            employee.Fullname = fullname;
            employee.Salary = salary;
            employee.Position = position;
        }

        public void RemoveEmployee(string EmployeNo)
        {
            for (int i = 0; i < _employees.Length; i++)
            {
                if (_employees[i] != null && _employees[i].No.ToUpper() == EmployeNo.ToUpper())
                {
                    _employees[i] = null;
                    return;
                }
            }
        }
    }
}
