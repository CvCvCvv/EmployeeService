using EmployeeService.DTOs;
using EmployeeService.Models;
using EmployeeService.Repositories;

namespace EmployeeService.Commands
{
    public class EmployeeCommands : IEmployeeCommands
    {
        private readonly IEmployeeCommandsRepository _employeeCommandsRepository;
        public EmployeeCommands(IEmployeeCommandsRepository employeeCommandsRepository)
        {
            _employeeCommandsRepository = employeeCommandsRepository;
        }
        public async Task<int> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            Employee newEmployee = new Employee()
            {
                DateOfEmployment = employeeCreateDto.DateOfEmployment,
                DepartmentId = employeeCreateDto.DepartmentId,
                JobPostId = employeeCreateDto.JobPostId,
                Tariff = employeeCreateDto.Tariff
            };

            Person newPerson = new Person()
            {
                DateOfBirth = employeeCreateDto.DateOfBirth,
                Firstname = employeeCreateDto.Firstname,
                Patronymic = employeeCreateDto.Patronymic,
                Surname = employeeCreateDto.Surname
            };

            return await _employeeCommandsRepository.CreateEmployeeAsync(newEmployee, newPerson);
        }

        public async Task DeleteEmployeeAsync(EmployeeGetDto employeeGetDto)
        {
            await _employeeCommandsRepository.DeleteEmployeeAsync(employeeGetDto.Id);
        }

        public async Task EditEmployeeAsync(EmployeeEditDto employeeEditDto)
        {
            Employee editEmployee = new Employee()
            {
                Id = employeeEditDto.Id,
                DateOfEmployment = employeeEditDto.DateOfEmployment,
                DepartmentId = employeeEditDto.DepartmentId,
                JobPostId = employeeEditDto.JobPostId,
                Tariff = employeeEditDto.Tariff
            };

            Person editPerson = new Person()
            {
                DateOfBirth = employeeEditDto.DateOfBirth,
                Firstname = employeeEditDto.Firstname,
                Patronymic = employeeEditDto.Patronymic,
                Surname = employeeEditDto.Surname
            };

            await _employeeCommandsRepository.EditEmployeeAsync(editEmployee, editPerson);
        }
    }
}
