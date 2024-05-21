using Azure;
using EFPractice.Data;
using EFPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class EmployeeController : ControllerBase
    {
        PrjContext context;
        public EmployeeController(PrjContext prjContext)
        {
            context = prjContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpGet("GetEmployeeByName/{name}")]
        public async Task<ActionResult<Employee>> GetEmployeeByName(string name)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(e => e.Name == name);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpGet("GetEmployeesByDescription/{description}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByDescription(string description)
        {
            var employees = await context.Employees.Where(e => e.Description.Contains(description)).ToListAsync();

            if (employees == null || employees.Count == 0)
            {
                return NotFound();
            }

            return employees;
        }

        [HttpGet("GetEmployeesByPartialDescription/{partialDescription}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByPartialDescription(string partialDescription)
        {
            var employees = await context.Employees.Where(e => e.Description.Contains(partialDescription)).ToListAsync();

            if (employees == null || employees.Count == 0)
            {
                return NotFound();
            }

            return employees;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            context.Entry(employee).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            context.Employees.Remove(employee);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return context.Employees.Any(e => e.Id == id);
        }
    }









}


