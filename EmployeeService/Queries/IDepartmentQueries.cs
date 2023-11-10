using EmployeeService.DTOs;

namespace EmployeeService.Queries
{
    public interface IDepartmentQueries
    {
        public Task<DepartmentDto> GetDepartmentByIdAsync(DepartmentGetDto departmentGetDto);
        public Task<List<DepartmentDto>> GetAllDepartmentAsync();
        public bool IsExistsId(int id);
        public bool IsExistsByName(int id, string name);
        public bool IsExistsByName(string name);
    }
}
