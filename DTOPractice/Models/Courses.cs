using System.ComponentModel.DataAnnotations;

namespace DtoPractice.Models
{
    public class Courses
    {
        [Key] public int CourseId {  get; set; }
        public string CourseName { get; set; }

    }
}
