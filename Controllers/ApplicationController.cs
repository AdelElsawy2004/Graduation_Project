using Graduation_Project.Models;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationServivces applicationServivces;

        public ApplicationController(IApplicationServivces applicationServivces)
        {
            this.applicationServivces = applicationServivces;
        }


        [HttpGet("GetMyApplications")]
        [Authorize(Roles = Roles.Applicant)]
        public async Task<IActionResult> GetApplicationByApplicant()
        {
            var profileIdClaim = User.FindFirstValue(CustomClaims.ProfileId);

            if (!int.TryParse(profileIdClaim, out int applicantId))
                return Unauthorized("Invalid or missing ProfileId");

            var result = await applicationServivces.GetApplicationByApplicant(applicantId);

            if (result == null || !result.Any())
                return NotFound("No applications found");

            return Ok(result);
        }
    }
}
