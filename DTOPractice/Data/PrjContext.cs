using DtoPractice.Models;
using Microsoft.EntityFrameworkCore;
namespace DtoPractice.Data
{
    public class PrjContext : DbContext
    {
        public PrjContext(DbContextOptions<PrjContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }



    }
}
