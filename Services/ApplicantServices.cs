using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Services
{
    public class ApplicantServices : IApplicantServices
    {
        private readonly ApplicationDbContext dbContext;

        public ApplicantServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Applicant> CreateApplicantAsync(Applicant applicant)
        {
          await dbContext.Applicants.AddAsync(applicant);
            await dbContext.SaveChangesAsync();
            return applicant;
        }

        public async Task<bool> DeleteApplicantAsync(int id)
        {
            var applicant = await this.GetApplicantByIdAsync(id);
            if (applicant == null)
                return false;
            else
            {
                dbContext.Applicants.Remove(applicant);
              await dbContext.SaveChangesAsync();
                return true;
            }
        }

        public Task<List<Applicant>> GetAllApplicantAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Applicant> GetApplicantByIdAsync(int id)
        {
            var foundedApplicant=await dbContext.Applicants.FirstOrDefaultAsync(x=>x.ApplicantID==id);
            return foundedApplicant;

        }

        public async Task<bool> UpdateApplicantAsync(int id, Applicant applicant)
        {
            var foundedApplicant =await this.GetApplicantByIdAsync(id);
            if (foundedApplicant == null)
                return false;
            foundedApplicant.Location = applicant.Location;
            foundedApplicant.FirstName = applicant.FirstName;
            foundedApplicant.LastName = applicant.LastName;
            foundedApplicant.PhoneNumber = applicant.PhoneNumber;
            dbContext.Applicants.Update(foundedApplicant);
           await  dbContext.SaveChangesAsync();
            return true;

        }
    }
}
