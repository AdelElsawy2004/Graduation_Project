namespace Graduation_Project.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string WebsiteURL { get; set; }
        public string HeadquarterAddress { get; set; }

        // FK to Identity User
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        // Relations
        public ICollection<JobPosting> JobPostings { get; set; }
    }
}
