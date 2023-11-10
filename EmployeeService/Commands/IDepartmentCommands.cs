using EmployeeService.DTOs;

namespace EmployeeService.Commands
{
    public interface IDepartmentCommands
    {
        public Task<int> CreateDepartmentAsync(DepartmentCreateDto departmentCreateDto);
        public Task EditDepartmentAsync(DepartmentEditDto departmentEditDto);
        public Task DeleteDepartmentAsync(DepartmentGetDto departmentGetDto);
    }
}
