using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IJobPostCommandsRepository
    {
        public Task<int> CreateJobPostAsync(JobPost jobPost);
        public Task DeleteJobPostAsync(int id);
        public Task EditjobPostAsync(JobPost jobPost);
    }
}
