using EmployeeService.DTOs;

namespace EmployeeService.Commands
{
    public interface IEmployeeCommands
    {
        public Task<int> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto);
        public Task EditEmployeeAsync(EmployeeEditDto employeeEditDto);
        public Task DeleteEmployeeAsync(EmployeeGetDto employeeGetDto);
    }
}
