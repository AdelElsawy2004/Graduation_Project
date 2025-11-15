namespace Graduation_Project.Models
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string SkillName { get; set; }

        // Navigation
        public ICollection<ApplicantSkill> ApplicantSkills { get; set; }
    }
}
