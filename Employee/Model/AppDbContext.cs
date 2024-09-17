using Microsoft.EntityFrameworkCore;

namespace Employee.Model
{
    public class AppDbContext:DbContext
    {
        private string connectionString;
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }

        public DbSet<_Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<_Employee>()
                .HasOne(e => e.Manager)
                .WithMany()
                .HasForeignKey(e=>e.ManagerID)
                .OnDelete(DeleteBehavior.Restrict);
                ;

            modelBuilder.Entity<Department>()
                .HasOne(e => e.Manager)
                .WithMany()
                .HasForeignKey(e => e.ManagerID)
                .OnDelete(DeleteBehavior.Restrict);
            ;
        }
        
    }
}
