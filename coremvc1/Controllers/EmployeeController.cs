using Microsoft.AspNetCore.Mvc;
using coremvc1.Models;


namespace coremvc1.Controllers
{
    public class EmployeeController : Controller
    {


        public List<Employee> EmployeesList()
        {
            List<Employee> employees = new List<Employee>();

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

            return employees;

        }


        public List<Course> CourseList()
        {
            List<Course> course = new List<Course>();

            Course course1 = new Course()
            {
                CourseId = 1,
                CourseName = "Test"
            };
            Course course2 = new Course()
            {
                CourseId = 2,
                CourseName = "Test"
            };
            Course course3 = new Course()
            {
                CourseId = 3,
                CourseName = "Test"
            };
            Course course4 = new Course()
            {
                CourseId = 4,
                CourseName = "Test"
            };

            course.Add(course1);
            course.Add(course2);
            course.Add(course3);
            return course;
        }

        public ViewResult ShowEmployees()
        {
            List<Employee> employees = EmployeesList();
            ViewBag.Title = "list of employees";
            ViewBag.Employees = employees;
            return View();
        }
        public ViewResult DisplayEmployees()
        {
            List<Employee> employees = EmployeesList();
           
            return View(employees);
        }

        public ViewResult DisplayCommonObj()
        {
            Common common = new Common();
            common.EmployeesList= EmployeesList();
            common.CourseList = CourseList();

            return View(common);
        }

    }
}
