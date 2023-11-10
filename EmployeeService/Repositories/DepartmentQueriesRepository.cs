using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class DepartmentQueriesRepository : IDepartmentQueriesRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentQueriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public bool IsExistsByName(int id, string name)
        {
            var department = _context.Departments.Find(id)!;
            if (department == null)
            {
                return true;
            }
            else if (department.Name == name)
            {
                return false;
            }
            return false;

        }

        public bool IsExistsByName(string name)
        {
            return _context.Departments.FirstOrDefault(a => a.Name == name) != null;
        }

        public bool IsExistsId(int id)
        {
            return _context.Departments.Find(id) != null;
        }
    }
}
