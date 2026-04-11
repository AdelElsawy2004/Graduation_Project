using Graduation_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Services
{
    public class ProfileService:IProfileService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<(string profileId, string profileType)> GetProfileAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            if (role == null)
                return (null, null);

            switch (role)
            {
                case Roles.Applicant:
                    var applicant = await _context.Applicants
                        .FirstOrDefaultAsync(x => x.UserId == user.Id);

                    return (applicant?.ApplicantID.ToString(), "Applicant");

                //case "Company":
                //    var company = await _context.Companies
                //        .FirstOrDefaultAsync(x => x.UserId == user.Id);

                //    return (company?.Id.ToString(), "Company");

                //case "Admin":
                //    var admin = await _context.Admins
                //        .FirstOrDefaultAsync(x => x.UserId == user.Id);

                //    return (admin?.Id.ToString(), "Admin");

                default:
                    return (null, role);
            }
        }
    }
}
