namespace FindPro.DAL.DataModels
{
    public class EmployeeDataModel : BaseDataModel
    {
        public Guid? GraderId { get; set; }
        
        public EmployeeDataModel Grader { get; set; }
        public List<EmployeeSkillDataModel> EmployeeSkills { get; set; }
    }
}
