using System.ComponentModel.DataAnnotations.Schema;

namespace LINQPractice.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
      
        public string Role { get; set; }
        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }

       
    }
}


