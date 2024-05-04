namespace FindPro.DAL.Filters
{
    public class EmployeeFilter : BaseFilter
    {
        public Guid? GraderId { get; set; }
        public List<Guid> SkillIds { get; set; }
        public bool? IncludeEmployeeSkills { get; set; }
    }
}
