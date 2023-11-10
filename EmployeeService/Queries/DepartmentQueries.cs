using EmployeeService.DTOs;
using EmployeeService.Repositories;

namespace EmployeeService.Queries
{
    public class DepartmentQueries : IDepartmentQueries
    {
        private readonly IDepartmentQueriesRepository _departmentQueriesRepository;
        public DepartmentQueries(IDepartmentQueriesRepository departmentQueriesRepository)
        {
            _departmentQueriesRepository = departmentQueriesRepository;
        }

        public async Task<List<DepartmentDto>> GetAllDepartmentAsync()
        {
            List<DepartmentDto> departmentsDto = new();
            var departments = await _departmentQueriesRepository.GetAllAsync();
            foreach (var department in departments)
            {
                departmentsDto.Add(new DepartmentDto()
                {
                    Id = department.Id,
                    Name = department.Name
                });
            }
            return departmentsDto;
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(DepartmentGetDto departmentGetDto)
        {
            var department = await _departmentQueriesRepository.GetByIdAsync(departmentGetDto.Id);
            return new DepartmentDto() { Id = department.Id, Name = department.Name };
        }

        public bool IsExistsByName(int id, string name)
        {
            return _departmentQueriesRepository.IsExistsByName(id, name);
        }

        public bool IsExistsByName(string name)
        {
            return _departmentQueriesRepository.IsExistsByName(name);
        }

        public bool IsExistsId(int id)
        {
            return _departmentQueriesRepository.IsExistsId(id);
        }
    }
}
