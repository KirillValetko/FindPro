namespace FindPro.Web.Models.DtoModels
{
    public class SkillGroupDto : BaseWebModel
    {
        public string GroupName { get; set; }

        public List<SkillLevelDto> SkillLevels { get; set; }
    }
}
