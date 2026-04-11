using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.Dtos
{
    public class ApplicantRegisterDto
    {

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        // Applicant profile fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
    }
}
