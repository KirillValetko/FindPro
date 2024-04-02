namespace FindPro.DAL.Filters
{
    public class SkillFilter : BaseFilter
    {
        public string SkillName { get; set; }
        public bool? IncludeSkillGroup { get; set; }
    }
}
