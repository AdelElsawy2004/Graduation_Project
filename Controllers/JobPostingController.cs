using Graduation_Project.Models;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingController : ControllerBase
    {
        private readonly IJobPostingService _service;

        public JobPostingController(IJobPostingService service)
        {
            _service = service;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _service.GetAllJobsAsync();
            return Ok(jobs);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await _service.GetJobByIdAsync(id);
            if (job == null) return NotFound("Job not found");

            return Ok(job);
        }

        
        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetByCompany(int companyId)
        {
            var jobs = await _service.GetJobsByCompanyAsync(companyId);
            return Ok(jobs);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobPosting job)
        {
            var newJob = await _service.CreateJobAsync(job);
            return Ok(newJob);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JobPosting job)
        {
            var updated = await _service.UpdateJobAsync(id, job);
            if (updated == null) return NotFound("Job not found");

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteJobAsync(id);
            if (!deleted) return NotFound("Job not found");

            return Ok("Job deleted");
        }

        
        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var success = await _service.DeactivateJobAsync(id);
            if (!success) return NotFound("Job not found");

            return Ok("Job deactivated");
        }

    }
}
