using EntityFrameworkDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
    public class ConsoleDbContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducation { get; set; }

        public ConsoleDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0LKSRK2;Initial Catalog=Study;Trusted_Connection=True;TrustServerCertificate=True");

        }
    }
}

