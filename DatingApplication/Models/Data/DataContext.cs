using Microsoft.EntityFrameworkCore;

namespace DatingApplication.Models.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

      public DbSet<Customer> Customers {get;set;}
      public DbSet<Users> Users { get; set; }
      public DbSet<Photos> Photos {get;set;}
    }
}