namespace FindPro.Web.Models.ViewModels
{
    public class EmployeeSkillViewModel : BaseWebModel
    {
        public SkillViewModel Skill { get; set; }
        public List<GradeViewModel> Grades { get; set; }
    }
}
