using Microsoft.EntityFrameworkCore;
using ShopMonitoring.Models;

namespace ShopMonitoring.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> opt) : base(opt)
        {

        }
        
        public DbSet<Customer> Customers { get; set; }
        
    }
}
