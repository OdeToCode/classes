using System.Data.Entity;
using EmployeeTimeCards.Core;

namespace EmployeeTimeCards.Web.Infrastructure
{    
    public class TimeCardContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PayPeriod> PayPeriods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .Property(e => e.FirstName)
                        .HasMaxLength(80);
                                    
            base.OnModelCreating(modelBuilder);
        }
    }
}