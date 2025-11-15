using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Graduation_Project.Models
{
    public class JobPosting
    {
        [Key]
        public int JobID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string SalaryRange { get; set; }
        public DateTime PostedDate { get; set; }
        public bool IsActive { get; set; }

        // FK
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        // Navigation
        public ICollection<Application> Applications { get; set; }
        public JobMetric JobMetric { get; set; }
    }
}
