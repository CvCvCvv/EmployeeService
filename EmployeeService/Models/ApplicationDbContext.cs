using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<JobPost> JobPosts { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 1, Name = "коммерческий отдел" },
                new Department() { Id = 2, Name = "производственный отдел" },
                new Department() { Id = 3, Name = "конструкторский отдел" }
                );

            modelBuilder.Entity<JobPost>().HasData(
                new JobPost() { Id = 1, Name = "директор", SalaryIncrement = 2.5d },
                new JobPost() { Id = 2, Name = "заведующий архивом", SalaryIncrement = 2.1d },
                new JobPost() { Id = 3, Name = "менеджер", SalaryIncrement = 2d },
                new JobPost() { Id = 4, Name = "мастер", SalaryIncrement = 2d }
                );

            modelBuilder.Entity<Person>().HasData(
               new Person() { Id = 1, DateOfBirth = new DateTime(1993, 12, 12), Firstname = "Андрей", Surname = "Иванов", Patronymic = "Васильевич" },
               new Person() { Id = 2, DateOfBirth = new DateTime(1983, 6, 5), Firstname = "Артём", Surname = "Крылов", Patronymic = "Дмитриевич" },
               new Person() { Id = 3, DateOfBirth = new DateTime(1987, 03, 23), Firstname = "Милана", Surname = "Крючкова", Patronymic = "Максимовна" },
               new Person() { Id = 4, DateOfBirth = new DateTime(1977, 5, 11), Firstname = "Мария", Surname = "Кононова", Patronymic = "Арсентьевна" },
               new Person() { Id = 5, DateOfBirth = new DateTime(2000, 11, 18), Firstname = "Роман", Surname = "Орлов", Patronymic = "Маркович" },
               new Person() { Id = 6, DateOfBirth = new DateTime(1991, 7, 12), Firstname = "Вероника", Surname = "Сорокина", Patronymic = "Александровна" }
               );

            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, DateOfEmployment = new DateTime(2023, 2, 11), DepartmentId = 1, JobPostId = 1, PersonId = 1, Tariff = 20000 },
                new Employee() { Id = 2, DateOfEmployment = new DateTime(2023, 6, 9), DepartmentId = 2, JobPostId = 2, PersonId = 2, Tariff = 15000 },
                new Employee() { Id = 3, DateOfEmployment = new DateTime(2023, 3, 4), DepartmentId = 3, JobPostId = 3, PersonId = 3, Tariff = 10000 },
                new Employee() { Id = 4, DateOfEmployment = new DateTime(2023, 5, 3), DepartmentId = 1, JobPostId = 4, PersonId = 4, Tariff = 9000 },
                new Employee() { Id = 5, DateOfEmployment = new DateTime(2023, 6, 8), DepartmentId = 2, JobPostId = 2, PersonId = 5, Tariff = 5000 },
                new Employee() { Id = 6, DateOfEmployment = new DateTime(2023, 11, 10), DepartmentId = 3, JobPostId = 1, PersonId = 6, Tariff = 12000 }
                );
        }
    }
}
