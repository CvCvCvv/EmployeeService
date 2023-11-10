using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public class DepartmentCommandsRepository : IDepartmentCommandsRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentCommandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department.Id;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            Department department = _context.Departments.Find(id)!;
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task EditDepartmentAsync(Department department)
        {
            Department editedDepartment = _context.Departments.Find(department.Id)!;
            editedDepartment.Name = department.Name;
            _context.Departments.Update(editedDepartment);
            await _context.SaveChangesAsync();
        }
    }
}
