using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IEmployeeCommandsRepository
    {
        public Task<int> CreateEmployeeAsync(Employee employee, Person person);
        public Task DeleteEmployeeAsync(int id);
        public Task EditEmployeeAsync(Employee employee, Person person);
    }
}
