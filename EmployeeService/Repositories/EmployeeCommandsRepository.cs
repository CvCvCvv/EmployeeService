using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class EmployeeCommandsRepository : IEmployeeCommandsRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeCommandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployeeAsync(Employee employee, Person person)
        {
            employee.Person = person;
            await _context.Employees.AddAsync(employee);
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee!);
            await _context.SaveChangesAsync();
        }

        public async Task EditEmployeeAsync(Employee employee, Person person)
        {
            var editedEmployee = await _context.Employees.Include(a => a.Person).FirstOrDefaultAsync(a => a.Id == employee.Id);

            editedEmployee!.Person.Surname = person.Surname;
            editedEmployee!.Person.Patronymic = person.Patronymic;
            editedEmployee!.Person.DateOfBirth = person.DateOfBirth;
            editedEmployee!.Person.Firstname = person.Firstname;

            editedEmployee.DateOfEmployment = employee.DateOfEmployment;
            editedEmployee.JobPost = _context.JobPosts.Find(employee.JobPostId)!;
            editedEmployee.Department = _context.Departments.Find(employee.DepartmentId)!;

            await _context.SaveChangesAsync();

        }
    }
}
