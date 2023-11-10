using EmployeeService.DTOs;
using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IEmployeeQueriesRepository
    {
        public Task<Employee> GetByIdAsync(int id);
        public bool IsExistsId(int id);
        public Task<List<Employee>> GetAllAsync();
        public Task<List<Employee>> GetFilteredAsync(EmployeeFilterDto employeeFilterDto);
    }
}
