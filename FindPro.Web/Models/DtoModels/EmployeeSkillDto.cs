namespace FindPro.Web.Models.DtoModels
{
    public class EmployeeSkillDto : BaseWebModel
    {
        public Guid SkillId { get; set; }

        public List<GradeDto> Grades { get; set; }
    }
}
