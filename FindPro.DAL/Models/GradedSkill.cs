namespace FindPro.DAL.Models
{
    public class GradedSkill : BaseDbModel
    {
        public string Comment { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid SkillId { get; set; }
        public Guid SkillLevelId { get; set; }

        public Employee Employee { get; set; }
        public Skill Skill { get; set; }
        public SkillLevel SkillLevel { get; set; }
    }
}
