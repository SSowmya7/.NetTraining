using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LINQPractice.Models;
namespace LINQPractice.Data
{
    public class PrjContext : DbContext
    {
        public PrjContext(DbContextOptions<PrjContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        
        


    }
}
