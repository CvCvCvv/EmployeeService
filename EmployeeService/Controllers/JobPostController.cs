using EmployeeService.Commands;
using EmployeeService.DTOs;
using EmployeeService.Queries;
using Hackathon.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    public class JobPostController : APIv1Conntroller
    {
        private readonly IJobPostCommands _jobPostCommands;
        private readonly IJobPostQueries _jobPostQueries;
        public JobPostController(IJobPostCommands jobPostCommands, IJobPostQueries jobPostQueries)
        {
            _jobPostCommands = jobPostCommands;
            _jobPostQueries = jobPostQueries;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(JobPostCreateDto jobPostCreateDto)
        {
            var result = await _jobPostCommands.CreateJobPostAsync(jobPostCreateDto);

            return new JsonResult(new { id = result });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(JobPostGetDto jobPostGetDto)
        {
            await _jobPostCommands.DeleteJobPostAsync(jobPostGetDto);

            return Ok();
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(JobPostEditDto jobPostEditDto)
        {
            await _jobPostCommands.EditJobPostAsync(jobPostEditDto);

            return Ok();
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(JobPostGetDto jobPostGetDto)
        {
            var result = await _jobPostQueries.GetJobPostByIdAsync(jobPostGetDto);

            return new JsonResult(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jobPostQueries.GetAllJobPostAsync();

            return new JsonResult(result);
        }
    }
}
