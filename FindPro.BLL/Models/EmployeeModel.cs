namespace FindPro.BLL.Models
{
    public class EmployeeModel : BaseModel
    {
        public Guid? GraderId { get; set; }

        public EmployeeModel Grader { get; set; }
        public List<EmployeeSkillModel> EmployeeSkills { get; set; }
    }
}
