using EmployeeService.DTOs;

namespace EmployeeService.Commands
{
    public interface IJobPostCommands
    {
        public Task<int> CreateJobPostAsync(JobPostCreateDto jobPostCreateDto);
        public Task EditJobPostAsync(JobPostEditDto jobPostEditDto);
        public Task DeleteJobPostAsync(JobPostGetDto jobPostGetDto);
    }
}
