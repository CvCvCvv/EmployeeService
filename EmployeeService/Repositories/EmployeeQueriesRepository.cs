using EmployeeService.DTOs;
using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class EmployeeQueriesRepository : IEmployeeQueriesRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeQueriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.Include(a => a.Person).Include(a => a.JobPost).Include(a => a.Department).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.Include(a => a.Person).Include(a => a.Department).Include(a => a.JobPost).FirstOrDefaultAsync(a => a.Id == id);
            return employee!;
        }

        public async Task<List<Employee>> GetFilteredAsync(EmployeeFilterDto employeeFilterDto)
        {
            IQueryable<Employee> employees = _context.Employees.Include(a => a.Person).Include(a => a.Department).Include(a => a.JobPost);

            if (employeeFilterDto.JobPostId > 0)
            {
                employees = employees.Where(a => a.JobPostId == employeeFilterDto.JobPostId);
            }

            switch (employeeFilterDto.SortBy)
            {
                case "fio":
                default:
                    employees = employeeFilterDto.SortDescending ? employees.OrderByDescending(a => a.Person.Surname)
                        .OrderByDescending(a => a.Person.Firstname)
                        .OrderByDescending(a => a.Person.Patronymic) :
                        employees.OrderBy(a => a.Person.Surname)
                        .OrderBy(a => a.Person.Firstname)
                        .OrderBy(a => a.Person.Patronymic);
                    break;
            }

            employees = employees.Skip(employeeFilterDto.CountLoaded).Take(employeeFilterDto.CountLoading);

            return await employees.ToListAsync();
        }

        public bool IsExistsId(int id)
        {
            return _context.Employees.Find(id) != null;
        }
    }
}
