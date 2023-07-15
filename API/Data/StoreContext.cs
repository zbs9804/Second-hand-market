//handle db interaction using DbContext
//A DbContext instance represents a session with the database and 
//can be used to query and save instances of your entities
//DbContext is a combination of the Unit Of Work and Repository patterns
using Microsoft.EntityFrameworkCore;
using API.Entities;
namespace API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }//DbSet basically represents a table
    }
}