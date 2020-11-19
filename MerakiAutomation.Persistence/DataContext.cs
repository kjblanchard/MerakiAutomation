using MerakiAutomation.Domain;
using Microsoft.EntityFrameworkCore;

namespace MerakiAutomation.Persistence
{
    public class DataContext : DbContext
    {
        #region Configuration

        #endregion


            public DataContext(DbContextOptions options) : base(options)
            {
            }
            
            public DbSet<Employee> Employees { get; set; }
            
            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.Entity<Employee>()
                    .HasData(
                        new Employee {Id = 1, Name = "Kevin", Title = "Network Admin"},
                        new Employee {Id = 2, Name = "Brandon", Title = "Network Senior"},
                        new Employee {Id = 3, Name = "Gabe", Title = "Manager"}
                    );
            }
        

        #region Methods

        #endregion
    }
}