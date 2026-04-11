namespace Graduation_Project.Models
{
    public class SavedJobs
    {
        public int Id { get; set; }
        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }

        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public DateTime SavedAt { get; set; } = DateTime.UtcNow;
    }
}
