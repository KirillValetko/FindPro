namespace FindPro.Web.Models.ViewModels
{
    public class GradeViewModel : BaseWebModel
    {
        public DateTime GradeDate { get; set; }
        public string Comment { get; set; }

        public SkillLevelViewModel SkillLevel { get; set; }
    }
}
