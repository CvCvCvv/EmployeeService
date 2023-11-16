using EmployeeService.DTOs;
using EmployeeService.Repositories;
using EmployeeService.Models;

namespace EmployeeService.Queries
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private readonly IEmployeeQueriesRepository _employeeQueriesRepository;
        public EmployeeQueries(IEmployeeQueriesRepository employeeQueriesRepository)
        {
            _employeeQueriesRepository = employeeQueriesRepository;
        }
        public async Task<List<EmployeeDto>> GetAllEmployeeAsync()
        {
            var allEmployees = await _employeeQueriesRepository.GetAllAsync();
            var allEmployeesDto = new List<EmployeeDto>();

            foreach (var employee in allEmployees)
            {
                allEmployeesDto.Add(new EmployeeDto()
                {
                    DateOfBirth = employee.Person.DateOfBirth,
                    DateOfEmployment = employee.DateOfEmployment,
                    Department = employee.Department.Name,
                    DepartmentId = employee.DepartmentId,
                    Firstname = employee.Person.Firstname,
                    JobPost = employee.JobPost.Name,
                    Id = employee.Id,
                    JobPostId = employee.JobPostId,
                    Patronymic = employee.Person.Patronymic,
                    Salary = employee.Tariff * employee.JobPost.SalaryIncrement,
                    Surname = employee.Person.Surname,
                    Tariff = employee.Tariff
                });
            }
            return allEmployeesDto;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(EmployeeGetDto employeeGetDto)
        {
            Employee employee = await _employeeQueriesRepository.GetByIdAsync(employeeGetDto.Id);
            EmployeeDto employeeDto = new EmployeeDto()
            {
                DateOfBirth = employee.Person.DateOfBirth,
                DateOfEmployment = employee.DateOfEmployment,
                Department = employee.Department.Name,
                DepartmentId = employee.DepartmentId,
                Firstname = employee.Person.Firstname,
                JobPost = employee.JobPost.Name,
                Id = employee.Id,
                JobPostId = employee.JobPostId,
                Patronymic = employee.Person.Patronymic,
                Salary = employee.Tariff * employee.JobPost.SalaryIncrement,
                Surname = employee.Person.Surname,
                Tariff = employee.Tariff
            };

            return employeeDto;
        }

        public async Task<EmployeeFilteredDto> GetFilteredEmployeeAsync(EmployeeFilterDto employeeFilterDto)
        {
            (List<Employee> employees, int countPages) = await _employeeQueriesRepository.GetFilteredAsync(employeeFilterDto);
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                employeeDtos.Add(new EmployeeDto()
                {
                    DateOfBirth = employee.Person.DateOfBirth,
                    DateOfEmployment = employee.DateOfEmployment,
                    Department = employee.Department.Name,
                    DepartmentId = employee.DepartmentId,
                    Firstname = employee.Person.Firstname,
                    Id = employee.Id,
                    JobPost = employee.JobPost.Name,
                    JobPostId = employee.JobPostId,
                    Patronymic = employee.Person.Patronymic,
                    Surname = employee.Person.Surname,
                    Salary = employee.Tariff * employee.JobPost.SalaryIncrement,
                    Tariff = employee.Tariff
                });
            }

            return new EmployeeFilteredDto() { employees = employeeDtos, Pages = countPages};

        }

        public bool IsExistsId(int id)
        {
            return _employeeQueriesRepository.IsExistsId(id);
        }
    }
}
