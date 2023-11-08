using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<JobPost> JobPosts { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
    }
}
