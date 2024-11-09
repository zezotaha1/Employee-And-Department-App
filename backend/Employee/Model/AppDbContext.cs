using Microsoft.EntityFrameworkCore;

namespace Employee.Model
{
    public class AppDbContext:DbContext
    {
        private string connectionString;
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }

        public DbSet<_Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        
    }
}
