using Graduation_Project.Models;

namespace Graduation_Project.Services
{
    public interface IJobPostingService
    {
        Task<IEnumerable<JobPosting>> GetAllJobsAsync();
        Task<JobPosting> GetJobByIdAsync(int id);
        Task<IEnumerable<JobPosting>> GetJobsByCompanyAsync(int companyId);
        Task<JobPosting> CreateJobAsync(JobPosting jobPosting);
        Task<JobPosting> UpdateJobAsync(int id, JobPosting jobPosting);
        Task<bool> DeleteJobAsync(int id);
        Task<bool> DeactivateJobAsync(int id);
    }
}
