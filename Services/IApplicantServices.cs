using Graduation_Project.Dtos;
using Graduation_Project.Models;

namespace Graduation_Project.Services
{
    public interface IApplicantServices
    {
        Task<Applicant> CreateApplicantAsync(Applicant applicant);
        Task<List<Applicant>> GetAllApplicantAsync();
        Task<Applicant> GetApplicantByIdAsync(int id);
        Task<bool> UpdateApplicantAsync(int id, ApplicantDto applicant);
        Task<bool> DeleteApplicantAsync(int id);
        Task<ApplicantDashboardResponseDto> GetDashboardAsync(int applicantId);
        Task<List<SavedJobsResponseDto>> GetSavedsAsync(int id);
    }
}
