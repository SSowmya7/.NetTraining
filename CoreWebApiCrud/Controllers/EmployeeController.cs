using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coremvc1.Models;

namespace CorewebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        // declaring a list to contain employee data
        public static List<Employee> employees = new List<Employee>();


        // adding some basic data to the list while creating instance
        static EmployeeController()
        {

            Employee employee1 = new Employee()
            {
                Id = 1,
                Name = "JOHN",
                Role = "ASE"
            };
            Employee employee2 = new Employee()
            {
                Id = 2,
                Name = "Alice",
                Role = "ASE"
            };
            Employee employee3 = new Employee()
            {
                Id = 3,
                Name = "David",
                Role = "ASE"
            };
            Employee employee4 = new Employee()
            {
                Id = 4,
                Name = "Mandy",
                Role = "ASE"
            };

            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);
            employees.Add(employee4);
        }



        //Employee crud
        

        //adding employee using post method
        [HttpPost("/addemployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok(employees);
        }

        // updating employee using put method
        [HttpPut("/updateemployee")]
        public IActionResult UpdateEmployee(int id, Employee obj)
        {

            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                {
                    emp.Name = obj.Name;
                    emp.Role = obj.Role;

                    break;
                }
            }

            return Ok(employees);

        }

        // dispalying one employee by taking id using get method
        [HttpGet("/GetEmployebyid")]
        public IActionResult DisplayEmployeeById(int id)
        {
            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                {
                    return Ok(emp);


                }
            }

            return Content("employee doesnot exist");

        }

        // dispalying employees by taking id using get method

        [HttpGet("/GetEmployees")]
        public List<Employee> GetEmployees()
        {

            return employees;
        }

        // deleting employees by taking id using delete method
        [HttpDelete("/deleteemployee")]
        public IActionResult DeleteEmployee(int id)
        {
            //employees.RemoveAt((id - 1));

            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                {
                    employees.Remove(emp);

                    return Ok(employees);

                }
            }

            
            return Content("employee doesnot exist");

        }

    }
}
