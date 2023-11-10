using EmployeeService.DTOs;

namespace EmployeeService.Queries
{
    public interface IJobPostQueries
    {
        public Task<JobPostDto> GetJobPostByIdAsync(JobPostGetDto jobPostGetDto);
        public Task<List<JobPostDto>> GetAllJobPostAsync();
        public bool IsExistsId(int id);
        public bool IsExistsByName(int id, string name);
        public bool IsExistsByName(string name);
    }
}
