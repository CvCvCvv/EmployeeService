using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public class JobPostCommandsRepository : IJobPostCommandsRepository
    {
        private readonly ApplicationDbContext _context;
        public JobPostCommandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateJobPostAsync(JobPost jobPost)
        {
            await _context.JobPosts.AddAsync(jobPost);
            await _context.SaveChangesAsync();
            return jobPost.Id;
        }

        public async Task DeleteJobPostAsync(int id)
        {
            _context.JobPosts.Remove(_context.JobPosts.Find(id)!);
            await _context.SaveChangesAsync();
        }

        public async Task EditjobPostAsync(JobPost jobPost)
        {
            JobPost jobPostEdited = _context.JobPosts.Find(jobPost.Id)!;
            jobPostEdited.Name = jobPost.Name;
            jobPostEdited.SalaryIncrement = jobPost.SalaryIncrement;
            await _context.SaveChangesAsync();
        }
    }
}
