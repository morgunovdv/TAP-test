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
        public DbSet<Skill> Skills { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Skill>()
        //        .HasOne(p => p.Person).WithMany(p => p.Skills);
                
        //}
    }
}
