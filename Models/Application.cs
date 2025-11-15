using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Graduation_Project.Models
{
    public class Application
    {
        [Key]
        public int ApplicationID { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime AppliedDate { get; set; }
        public string CoverLetter { get; set; }

        // FKs
        public int ApplicantID { get; set; }
        public Applicant Applicant { get; set; }

        [ForeignKey("JobPosting")]
        public int JobPostingID { get; set; }
        public JobPosting JobPosting { get; set; }

        public int? ResumeID { get; set; }
        public Resume? Resume { get; set; }
    }
}
