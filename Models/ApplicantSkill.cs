namespace Graduation_Project.Models
{
    public class ApplicantSkill
    {
        public int ApplicantSkillID { get; set; }
        public int ApplicantID { get; set; }
        public Applicant Applicant { get; set; }

        public int SkillID { get; set; }
        public Skill Skill { get; set; }

        public string ProficiencyLevel { get; set; }
    }
}
