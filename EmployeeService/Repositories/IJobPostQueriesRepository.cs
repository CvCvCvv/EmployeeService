using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IJobPostQueriesRepository
    {
        public Task<JobPost> GetByIdAsync(int id);
        public Task<List<JobPost>> GetAllAsync();
        public bool IsExistsId(int id);
        public bool IsExistsByName(int id, string name);
        public bool IsExistsByName(string name);
    }
}
