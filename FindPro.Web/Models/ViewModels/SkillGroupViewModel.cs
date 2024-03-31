namespace FindPro.Web.Models.ViewModels
{
    public class SkillGroupViewModel : BaseWebModel
    {
        public string GroupName { get; set; }

        public List<SkillLevelViewModel> SkillLevels { get; set; }
    }
}
