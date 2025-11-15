using Graduation_Project.Models;

namespace Graduation_Project.Services
{
    public interface IApplicantServices
    {
        Task<Applicant> CreateApplicantAsync(Applicant applicant);
        Task<List<Applicant>> GetAllApplicantAsync();
        Task<Applicant> GetApplicantByIdAsync(int id);
        Task<bool> UpdateApplicantAsync(int id, Applicant applicant);
        Task<bool> DeleteApplicantAsync(int id);
    }
}
