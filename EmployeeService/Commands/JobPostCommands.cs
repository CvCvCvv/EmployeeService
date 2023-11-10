using EmployeeService.DTOs;
using EmployeeService.Models;
using EmployeeService.Repositories;

namespace EmployeeService.Commands
{
    public class JobPostCommands : IJobPostCommands
    {
        private readonly IJobPostCommandsRepository _jobPostCommandsRepository;
        public JobPostCommands(IJobPostCommandsRepository jobPostCommandsRepository)
        {
            _jobPostCommandsRepository = jobPostCommandsRepository;
        }
        public async Task<int> CreateJobPostAsync(JobPostCreateDto jobPostCreateDto)
        {
            JobPost newJobPost = new JobPost() { Name = jobPostCreateDto.Name, SalaryIncrement = jobPostCreateDto.SalaryIncrement };
            return await _jobPostCommandsRepository.CreateJobPostAsync(newJobPost);
        }

        public async Task DeleteJobPostAsync(JobPostGetDto jobPostGetDto)
        {
            await _jobPostCommandsRepository.DeleteJobPostAsync(jobPostGetDto.Id);
        }

        public async Task EditJobPostAsync(JobPostEditDto jobPostEditDto)
        {
            JobPost editJobPost = new JobPost() { Id = jobPostEditDto.Id, Name = jobPostEditDto.Name, SalaryIncrement = jobPostEditDto.SalaryIncrement };
            await _jobPostCommandsRepository.EditjobPostAsync(editJobPost);
        }
    }
}
