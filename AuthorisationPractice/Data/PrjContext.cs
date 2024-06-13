using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthenticationPraction.Models;
namespace AuthenticationPraction.Data
{
    public class PrjContext : DbContext
    {
        public PrjContext(DbContextOptions<PrjContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<User> Users { get; set; }
        
        


    }
}
