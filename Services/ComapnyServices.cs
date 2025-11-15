using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Services
{
    public class ComapnyServices : ICompanyServices
    {
        private readonly ApplicationDbContext dbContext;

        public ComapnyServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Company> AddCompanyAsync(Company company)
        {
           await dbContext.Companies.AddAsync(company);
            await dbContext.SaveChangesAsync();
            return company;
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var company = await dbContext.Companies.FindAsync(id);
            if (company == null)
                return false;

          dbContext.Companies.Remove(company);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Company?> GetCompanyByIdAsync(int id)
        {
            return await dbContext.Companies
               .Include(c => c.User)
               .FirstOrDefaultAsync(c => c.CompanyID == id);
        }

        public async Task<Company?> GetCompanyByUserIdAsync(string userId)
        {
            return await dbContext.Companies
              .Include(c => c.User)
              .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<bool> UpdateCompanyAsync(int id, Company updatedCompany)
        {
            var company = await dbContext.Companies.FindAsync(id);
            if (company == null)
                return false;

            company.Name = updatedCompany.Name;
            company.WebsiteURL = updatedCompany.WebsiteURL;
            company.Industry = updatedCompany.Industry;
            company.HeadquarterAddress = updatedCompany.HeadquarterAddress;
         

            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
