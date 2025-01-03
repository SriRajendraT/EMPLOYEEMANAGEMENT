using EMPLOYEEMANAGEMENT.Models;
using Microsoft.EntityFrameworkCore;

namespace EMPLOYEEMANAGEMENT.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gender>().ToTable("GENDER");
            modelBuilder.Entity<Department>().ToTable("DEPARTMENT");
            modelBuilder.Entity<State>().ToTable("STATE");
            modelBuilder.Entity<City>().ToTable("CITY");
            modelBuilder.Entity<Employee>().ToTable("EMPLOYEE");
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
