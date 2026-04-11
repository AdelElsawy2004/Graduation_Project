using Graduation_Project.Models;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyServices companyServices;

        public CompanyController(ICompanyServices companyServices)
        {
            this.companyServices = companyServices;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await companyServices.GetCompanyByIdAsync(id);
            if (company == null) return NotFound();
            return Ok(company);
        }


        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCompanyByUserId(string userId)
        {
            var company = await companyServices.GetCompanyByUserIdAsync(userId);
            if (company == null) return NotFound();
            return Ok(company);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            if (!ModelState.IsValid) return BadRequest();

            var createdCompany = await companyServices.AddCompanyAsync(company);
            return CreatedAtAction(nameof(GetCompanyById), new { id = createdCompany.CompanyID }, createdCompany);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] Company updatedCompany)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await companyServices.UpdateCompanyAsync(id, updatedCompany);
            if (!result) return NotFound();

            return NoContent(); 
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await companyServices.DeleteCompanyAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
