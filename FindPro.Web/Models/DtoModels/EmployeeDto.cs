namespace FindPro.Web.Models.DtoModels
{
    public class EmployeeDto : BaseWebModel
    {
        public Guid? GraderId { get; set; }

        public List<EmployeeSkillDto> EmployeeSkills { get; set; }
    }
}
