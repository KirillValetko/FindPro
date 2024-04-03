namespace FindPro.DAL.Models
{
    public class EmployeeSkill : BaseDbModel
    {
        public Guid EmployeeId { get; set; }
        public Guid SkillId { get; set; }

        public Employee Employee { get; set; }
        public Skill Skill { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
