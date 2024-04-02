namespace FindPro.DAL.DataModels
{
    public class SkillDataModel : BaseDataModel 
    {
        public string SkillName { get; set; }
        public bool IsUsed { get; set; }
        public Guid GroupId { get; set; }

        public SkillGroupDataModel SkillGroup { get; set; }
    }
}
