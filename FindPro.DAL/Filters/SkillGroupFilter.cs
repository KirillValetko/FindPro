namespace FindPro.DAL.Filters
{
    public class SkillGroupFilter : BaseFilter
    {
        public string GroupName { get; set; }
        public bool? IncludeSkillLevels { get; set; }
    }
}
