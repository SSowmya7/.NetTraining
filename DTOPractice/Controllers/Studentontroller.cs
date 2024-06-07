using DtoPractice.Data;
using DtoPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DtoPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        PrjContext context;

        public StudentController(PrjContext prjContext)
        {
            context = prjContext;
        }

        [HttpGet("/GetAllStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return Ok(await context.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await context.Students.FindAsync(id);

            if (student == null)

            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("/AddStudent")]
        public async Task<IActionResult> Post(StudentDto studentdto)
        {
            Student student = new Student()
            {
                StudentId = studentdto.Id,
                Name = studentdto.Name,
                Department = studentdto.Department
            };
            context.Students.Add(student);
            await context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("/UpdateStudent")]
        public async Task<IActionResult> Put(StudentDto studentdto)
        {
            //Student UpdStudent = context.Students.Find(studentdto.Id);

            //if (UpdStudent == null)
            //{
            //    return BadRequest();
            //}
            Student student = new Student()
            {
                StudentId = studentdto.Id,
                Name = studentdto.Name,
                Department = studentdto.Department
            };
            context.Students.Update(student);
            await context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("/DeleteStudent")]
        public async Task<IActionResult> Delete(int id)
        {
            Student student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return BadRequest();
            }
            context.Students.Remove(student);
            await context.SaveChangesAsync();
            return Ok(student);
        }
    }
}
