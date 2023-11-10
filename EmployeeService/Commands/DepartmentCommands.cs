using EmployeeService.DTOs;
using EmployeeService.Models;
using EmployeeService.Repositories;

namespace EmployeeService.Commands
{
    public class DepartmentCommands : IDepartmentCommands
    {
        private readonly IDepartmentCommandsRepository _departmentCommandsRepository;
        public DepartmentCommands(IDepartmentCommandsRepository departmentCommandsRepository)
        {
            _departmentCommandsRepository = departmentCommandsRepository;
        }
        public async Task<int> CreateDepartmentAsync(DepartmentCreateDto departmentCreateDto)
        {
            Department newDepartment = new Department() { Name = departmentCreateDto.Name };
            return await _departmentCommandsRepository.CreateDepartmentAsync(newDepartment);
        }

        public async Task DeleteDepartmentAsync(DepartmentGetDto departmentGetDto)
        {
            await _departmentCommandsRepository.DeleteDepartmentAsync(departmentGetDto.Id);
        }

        public async Task EditDepartmentAsync(DepartmentEditDto departmentEditDto)
        {
            Department editDepartment = new Department() { Id = departmentEditDto.Id, Name = departmentEditDto.Name };
            await _departmentCommandsRepository.EditDepartmentAsync(editDepartment);
        }
    }
}
