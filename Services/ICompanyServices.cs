using Graduation_Project.Models;

namespace Graduation_Project.Services
{
    public interface ICompanyServices
    {
        Task<Company> AddCompanyAsync(Company company);
        Task<Company?> GetCompanyByIdAsync(int id);
        Task<Company?> GetCompanyByUserIdAsync(string userId);
        Task<bool> UpdateCompanyAsync(int id, Company updatedCompany);
        Task<bool> DeleteCompanyAsync(int id);
    }
}
