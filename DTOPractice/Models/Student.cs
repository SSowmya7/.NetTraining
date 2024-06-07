using System.ComponentModel.DataAnnotations;

namespace DtoPractice.Models
{
    public class Student
    {
        [Key] public int StudentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        
    }
}
