using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LINQPractice.Services;
using LINQPractice.Models;

namespace LINQPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLinqController : ControllerBase
    {
        EmployeeServices employeeServices;
        public EmployeeLinqController(EmployeeServices employeeService) {

            employeeServices = employeeService;
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var employees = await employeeServices.Get();
            var LinqEmployees = from employee in employees select employee;
            return Ok(LinqEmployees);
        }
        [HttpGet("/GetEmployeeById{Id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesById(int Id)
        {
            var employees = await employeeServices.EmployeesByDepartment(Id);
            return Ok(employees);
        }
        [HttpGet("/GetEmployeesCount")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesCount()
        {
            var employees = await employeeServices.EmployeesCount();
            return Ok(employees);
        }

        [HttpGet("/GetAvgEmployeeNameLength")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAvgNameLength()
        {
            var averageNameLength = await employeeServices.GetAvgNameLength();

            return Ok(averageNameLength);
        }

        [HttpGet("/GetEmployeeDepartment")]
        public async Task<ActionResult<EmployeeDepartmentDto>> GetEmployeeDepartment()
        {
            var EmployeesWithDepartments = await employeeServices.EmployeeInDepartment();
            return Ok(EmployeesWithDepartments);
        }
        [HttpGet("/SortedEmployeesByName")]
        public async Task<ActionResult<Employee>> GetSortedEmployeesByName()
        {
            var Employees = await employeeServices.SortedEmployeesByNames();
            return Ok(Employees);
        }

        [HttpGet("/DepartmentWiseEmployeeCount")]
        public async Task<ActionResult<IEnumerable<DepartmentWiseEmployeeCount>>> GetDepartmentWiseEmployeeCount()
        {
            var DepartmentWiseEmployeeCount = await employeeServices.GroupEmployeesByDept();
            return Ok(DepartmentWiseEmployeeCount);
        }

        [HttpGet("/deptwiseEmpAvg")]
        public async Task<IActionResult> DeptwiseEmpAvg()
        {
            var D = await employeeServices.GetAvgEmployeesInDept();
            return Ok(D);
        }


    }
}
