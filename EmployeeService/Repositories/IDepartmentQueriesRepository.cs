using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IDepartmentQueriesRepository
    {
        public Task<Department> GetByIdAsync(int id);
        public Task<List<Department>> GetAllAsync();
        public bool IsExistsByName(int id, string name);
        public bool IsExistsByName(string name);
        public bool IsExistsId(int id);
    }
}
