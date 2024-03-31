namespace FindPro.BLL.Models
{
    public class SkillLevelModel : BaseModel
    {
        public string LevelName { get; set; }
        public int LevelValue { get; set; }
        public string Description { get; set; }
        public bool IsUsed { get; set; }
        public Guid GroupId { get; set; }
    }
}
