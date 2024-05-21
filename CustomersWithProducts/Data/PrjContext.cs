using EFCustomerwithProducts.modals;
using Microsoft.EntityFrameworkCore;


namespace EFCustomerwithProducts.Data
{
    public class PrjContext : DbContext
    {
        public PrjContext(DbContextOptions<PrjContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomersWithProduct> CustomersWithProduct { get; set; }
       // public DbSet<PurchasedProducts> PurchasedProducts { get; set; }

       
    }
}
