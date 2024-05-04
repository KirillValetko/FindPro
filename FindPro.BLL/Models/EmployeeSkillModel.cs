namespace FindPro.BLL.Models
{
    public class EmployeeSkillModel : BaseModel
    {
        public Guid EmployeeId { get; set; }
        public Guid SkillId { get; set; }

        public SkillModel Skill { get; set; }
        public List<GradeModel> Grades { get; set; }
    }
}
