namespace FindPro.DAL.Models
{
    public class Employee : BaseDbModel
    {
        public Guid? GraderId { get; set; }
        
        public Employee Grader { get; set; }
        public List<GradedSkill> GradedSkills { get; set; }
    }
}
