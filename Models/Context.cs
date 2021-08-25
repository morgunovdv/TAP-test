using Microsoft.EntityFrameworkCore;

namespace TAP_test.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { 
        }

        public DbSet<Person> Persons { get; set; }
    }
}
