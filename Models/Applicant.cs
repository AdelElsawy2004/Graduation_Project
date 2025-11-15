using static System.Net.Mime.MediaTypeNames;

namespace Graduation_Project.Models
{
    public class Applicant
    {
        public int ApplicantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string? ProfilePicURL { get; set; }

        // FK to Identity User
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        // Relations
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Resume> Resumes { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<ApplicantSkill> ApplicantSkills { get; set; }
    }
}
