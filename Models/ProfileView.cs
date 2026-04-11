namespace Graduation_Project.Models
{
    public class ProfileView
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
