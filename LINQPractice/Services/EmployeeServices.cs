using LINQPractice.Contracts;
using LINQPractice.Data;
using LINQPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LINQPractice.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        PrjContext context;
        public EmployeeServices(PrjContext Prjcontext)
        {

            context = Prjcontext;
        }
        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = await context.Employees.ToListAsync();
            return employees;
        }

        public async Task<IEnumerable<Department>> GetD()
        {
            var employees = await context.Departments.ToListAsync();
            return employees;
        }
        public async Task<IEnumerable<Employee>> EmployeesByDepartment(int Id)
        {
            var employees = await context.Employees.Where(e => e.DepartmentId == Id).ToListAsync();
            return employees;
        }

        public async Task<int> EmployeesCount()
        {
            var employeeCount = context.Employees.Count();
            return employeeCount;
        }
        public async Task<double> GetAvgNameLength()
        {
            var averageNameLength = context.Employees.Average(e => e.Name.Length);
            
            return averageNameLength;
        }

        public async Task<IEnumerable<EmployeeDepartmentDto>> EmployeeInDepartment()
        {
            var employeeDepartments = from e in context.Employees
                                      join d in context.Departments
                                      on e.DepartmentId equals d.DepartmentId
                                      select new EmployeeDepartmentDto
                                      {
                                          EmployeeName = e.Name,
                                          DepartmentName = d.Name
                                      };
            return employeeDepartments;

        }

        public async Task<double> GetAvgEmployeesInDept()
        {
            var employeesCount = await GroupEmployeesByDept();
            var averageEmployees = employeesCount.Average(e => e.EmployeeCount);
           
            return averageEmployees;
        }

        public async Task<IEnumerable<Employee>> SortedEmployeesByNames()
        {
            var sortedEmployees = context.Employees.OrderBy(e => e.Name).ToList();
            return sortedEmployees;
        }
        
        public async Task<IEnumerable<DepartmentWiseEmployeeCount>> GroupEmployeesByDept()
        {
            var employeesByDepartment = from e in context.Employees
                                        group e by e.DepartmentId into deptGroup
                                        select new DepartmentWiseEmployeeCount
                                        {
                                            DepartmentId = deptGroup.Key,
                                            EmployeeCount = deptGroup.Count()
                                        };
            return employeesByDepartment;
        }
    }
}
