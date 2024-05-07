using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Employee
{
    public class EmployeeOperations
    {
        private ArrayList employees = new ArrayList();
        private int nextId = 1;
        
        public void AddEmployee(Employee employee)
        
        
        {
            employees.Add(new Employee(nextId,employee.Name,employee.Department,employee.Salary));
            nextId++;
           
        }

        public void UpdateEmployee(int id,Employee obj)
        {
           
            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                {
                    emp.Name = obj.Name;
                    emp.Department = obj.Department;
                    emp.Salary = obj.Salary;
                    break;
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            employees.RemoveAt((id - 1));
        }
        public ArrayList DisplayAllEmployees()
        {

            return employees;
        }
    }
}
