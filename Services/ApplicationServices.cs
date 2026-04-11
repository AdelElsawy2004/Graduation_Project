using Graduation_Project.Dtos;
using Graduation_Project.Migrations;
using Graduation_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Services
{
    public class ApplicationServices : IApplicationServivces
    {
        private readonly ApplicationDbContext dbContext;

        public ApplicationServices(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }
        public async Task<List<ApplicationDto>> GetApplicationByApplicant(int id)
        {
          
            var applications =await dbContext.Applications.Where(x => x.ApplicantID == id)
                .Select(x=> new ApplicationDto()
                {
                    ApplicationId=x.ApplicationID,
                    JobType = x.JobPosting.JobType.ToString(),
                    ApplicationStatus =x.ApplicationStatus.ToString(),
                    AppliedOn=x.AppliedDate,
                    JobTitle=x.JobPosting.Title,
                    CompanyName=x.JobPosting.Company.Name,
                    Location=x.JobPosting.Company.Location,
                    LogoUrl=x.JobPosting.Company.LogoUrl,
                    IsRemote=x.JobPosting.IsRemote




                }
                
                
                ).ToListAsync();
   
            return applications;

        }
    }
}
