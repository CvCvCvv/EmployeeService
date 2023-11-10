using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class JobPostQueriesRepository : IJobPostQueriesRepository
    {
        private readonly ApplicationDbContext _context;
        public JobPostQueriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<JobPost>> GetAllAsync()
        {
            return await _context.JobPosts.ToListAsync();
        }

        public async Task<JobPost> GetByIdAsync(int id)
        {
            return await _context.JobPosts.FindAsync(id);
        }

        public bool IsExistsByName(int id, string name)
        {
            var jobPost = _context.JobPosts.Find(id)!;
            if (jobPost == null)
            {
                return false;
            }
            else if (jobPost.Name == name)
            {
                return true;
            }
            return true;
        }

        public bool IsExistsByName(string name)
        {
            return _context.JobPosts.FirstOrDefault(a => a.Name == name) == null;
        }

        public bool IsExistsId(int id)
        {
            return _context.JobPosts.Find(id) != null;
        }
    }
}
