using Microsoft.EntityFrameworkCore;
using TestWebAPI.Models.DTO;

namespace TestWebAPI.DAL
{
    public class DbFactoryContext : DbContext
    {
        
        public DbSet<Customer> Customers { get; set; }

        

        public DbFactoryContext(DbContextOptions<DbFactoryContext> options)
           : base(options)
        {
       
        }

       


    }
}
