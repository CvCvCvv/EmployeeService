using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IDepartmentCommandsRepository
    {
        public Task<int> CreateDepartmentAsync(Department department);
        public Task DeleteDepartmentAsync(int id);
        public Task EditDepartmentAsync(Department department);
    }
}
