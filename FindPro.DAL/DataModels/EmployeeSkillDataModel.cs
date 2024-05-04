namespace FindPro.DAL.DataModels
{
    public class EmployeeSkillDataModel : BaseDataModel
    {
        public Guid EmployeeId { get; set; }
        public Guid SkillId { get; set; }

        public SkillDataModel Skill { get; set; }
        public List<GradeDataModel> Grades { get; set; }
    }
}
