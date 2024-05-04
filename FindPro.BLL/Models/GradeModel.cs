namespace FindPro.BLL.Models
{
    public class GradeModel : BaseModel
    {
        public DateTime GradeDate { get; set; }
        public string Comment { get; set; }
        public Guid SkillLevelId { get; set; }
        public Guid EmployeeSkillId { get; set; }

        public SkillLevelModel SkillLevel { get; set; }
    }
}
