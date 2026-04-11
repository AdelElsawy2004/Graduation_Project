using Graduation_Project.Dtos;
using Graduation_Project.Models;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantServices applicantServices;

        public ApplicantController(IApplicantServices applicantServices)
        {
            this.applicantServices = applicantServices;
        }
        [HttpGet("GetMyDashboard")]
        [Authorize(Roles = Roles.Applicant)]
        public async Task<IActionResult> GetApplicantByUserId()
        {
            var profileIdClaim = User.FindFirstValue(CustomClaims.ProfileId);

            if (!int.TryParse(profileIdClaim, out int applicantId))
                return Unauthorized("Invalid or missing ProfileId");
            var applicant = await applicantServices.GetDashboardAsync(applicantId);
            if (applicant == null)
                return NotFound("Applicant not found");
            return Ok(applicant);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicant([FromRoute]int id, [FromBody] ApplicantDto applicantDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid request");
            var result = await applicantServices.UpdateApplicantAsync(id, applicantDto);
            if (!result)
                return BadRequest("internal server error");
            return Ok("Applicant updated successfully");
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicant([FromRoute] int id)
        {
          var result= await applicantServices.DeleteApplicantAsync(id);
            if (!result)
                return NotFound("Applicant Not found");
            return Ok("Applicant deleted Succesfully");
        }
        [HttpGet("MysavedJobs")]
        [Authorize(Roles = Roles.Applicant)]
        public async Task<IActionResult> GetSavedJobsForApplicant()
        {
            var profileIdClaim = User.FindFirstValue(CustomClaims.ProfileId);

            if (!int.TryParse(profileIdClaim, out int applicantId))
                return Unauthorized("Invalid or missing ProfileId");
            var result=await applicantServices.GetSavedsAsync(applicantId);
            if (result == null)
                return BadRequest();
            return Ok(result);



        }

    }
}
