namespace FindPro.DAL.DataModels
{
    public class GradeDataModel : BaseDataModel
    {
        public DateTime GradeDate { get; set; }
        public string Comment { get; set; }
        public Guid SkillLevelId { get; set; }
        public Guid EmployeeSkillId { get; set; }

        public SkillLevelDataModel SkillLevel { get; set; }
    }
}
