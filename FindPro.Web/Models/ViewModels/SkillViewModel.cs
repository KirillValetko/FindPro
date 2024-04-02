namespace FindPro.Web.Models.ViewModels
{
    public class SkillViewModel : BaseWebModel
    {
        public string SkillName { get; set; }

        public SkillGroupViewModel SkillGroup { get; set; }
    }
}
