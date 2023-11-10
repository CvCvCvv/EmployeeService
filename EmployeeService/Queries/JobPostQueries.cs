using EmployeeService.DTOs;
using EmployeeService.Repositories;

namespace EmployeeService.Queries
{
    public class JobPostQueries : IJobPostQueries
    {
        private readonly IJobPostQueriesRepository _jobPostQueriesRepository;
        public JobPostQueries(IJobPostQueriesRepository jobPostQueriesRepository)
        {
            _jobPostQueriesRepository = jobPostQueriesRepository;
        }
        public async Task<List<JobPostDto>> GetAllJobPostAsync()
        {
            List<JobPostDto> jobPostsDto = new List<JobPostDto>();
            var jobPosts = await _jobPostQueriesRepository.GetAllAsync();

            foreach (var jobPost in jobPosts)
            {
                jobPostsDto.Add(new JobPostDto()
                {
                    Id = jobPost.Id,
                    Name = jobPost.Name,
                    SalaryIncrement = jobPost.SalaryIncrement
                });
            }

            return jobPostsDto;
        }

        public async Task<JobPostDto> GetJobPostByIdAsync(JobPostGetDto jobPostGetDto)
        {
            var jobPost = await _jobPostQueriesRepository.GetByIdAsync(jobPostGetDto.Id);

            return new JobPostDto() { Id = jobPost.Id, SalaryIncrement = jobPost.SalaryIncrement, Name = jobPost.Name };
        }

        public bool IsExistsByName(int id, string name)
        {
            return _jobPostQueriesRepository.IsExistsByName(id, name);
        }

        public bool IsExistsByName(string name)
        {
            return _jobPostQueriesRepository.IsExistsByName(name);
        }

        public bool IsExistsId(int id)
        {
            return _jobPostQueriesRepository.IsExistsId(id);
        }
    }
}
