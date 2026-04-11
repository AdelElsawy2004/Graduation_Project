using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly ApplicationDbContext dbContext;

        public JobPostingService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<JobPosting> CreateJobAsync(JobPosting jobPosting)
        {
            jobPosting.PostedDate = DateTime.Now;
            jobPosting.IsActive = true;
           await dbContext.JobPostings.AddAsync(jobPosting);
            await dbContext.SaveChangesAsync();
            return jobPosting;
            
        }

        public async Task<bool> DeactivateJobAsync(int id)
        {
           var result= await dbContext.JobPostings.FindAsync(id);
            if (result == null)
                return false;
            result.IsActive = false;
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteJobAsync(int id)
        {
            var result = await dbContext.JobPostings.FindAsync(id);
            if (result == null)
                return false;
            dbContext.Remove(result);
            await dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<JobPosting>> GetAllJobsAsync()
        {
            var jobs =await dbContext.JobPostings.Include(x => x.Company).ToListAsync();
            return jobs;
        }

        public async Task<JobPosting> GetJobByIdAsync(int id)
        {
            return await dbContext.JobPostings
             .Include(j => j.Company)
             .Include(j => j.Applications)
             .FirstOrDefaultAsync(j => j.JobID == id);
        }

        public async Task<IEnumerable<JobPosting>> GetJobsByCompanyAsync(int companyId)
        {
            var foundededJobs =await (dbContext.JobPostings.Where(x => x.CompanyID == companyId).ToListAsync());
            return foundededJobs;
        }

        public async Task<JobPosting> UpdateJobAsync(int id, JobPosting jobPosting)
        {
            var existing = await dbContext.JobPostings.FindAsync(id);

            if (existing == null) return null;

            existing.Title = jobPosting.Title;
            existing.Description = jobPosting.Description;
            existing.Requirements = jobPosting.Requirements;
            existing.SalaryRange = jobPosting.SalaryRange;
            existing.IsActive = jobPosting.IsActive;

            await dbContext.SaveChangesAsync();
            return existing;

        }
    }
}
