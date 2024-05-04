namespace FindPro.Web.Models.ViewModels
{
    public class EmployeeViewModel : BaseWebModel
    {
        public EmployeeViewModel Grader { get; set; }
        public List<EmployeeSkillViewModel> EmployeeSkills { get; set; }
    }
}
