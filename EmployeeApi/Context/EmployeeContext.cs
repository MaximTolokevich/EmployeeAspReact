using EmployeeApi.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Context
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeContext()
        { 
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Employee;Trusted_Connection=True;");
        }
    }
}
