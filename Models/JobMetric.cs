using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.Models
{
    public class JobMetric
    {
        [Key]
        public int MetricID { get; set; }
        public int Views { get; set; }
        public int ApplicationCount { get; set; }
        public DateTime LastUpdated { get; set; }

        // FK
        public int JobID { get; set; }
        public JobPosting JobPosting { get; set; }
    }
}
