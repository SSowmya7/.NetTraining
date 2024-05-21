using EFPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPractice.Data
{

    public class PrjContext : DbContext
        {
            public PrjContext(DbContextOptions<PrjContext> contextOptions) : base(contextOptions)
            { }

            public DbSet<Employee> Employees { get; set; }
            public DbSet<Customer> Customers { get; set; }


        }
    }

