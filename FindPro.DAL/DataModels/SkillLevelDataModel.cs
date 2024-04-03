namespace FindPro.DAL.DataModels
{
    public class SkillLevelDataModel : BaseDataModel
    {
        public string LevelName { get; set; }
        public int LevelValue { get; set; }
        public string Description { get; set; }
        public int GradeRevisionInMonths { get; set; }
        public bool IsUsed { get; set; }
        public Guid GroupId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherSkillLevel = (SkillLevelDataModel)obj;
            return Id == otherSkillLevel.Id
                   && LevelName == otherSkillLevel.LevelName
                   && LevelValue == otherSkillLevel.LevelValue
                   && Description == otherSkillLevel.Description
                   && GradeRevisionInMonths == otherSkillLevel.GradeRevisionInMonths;
        }
    }
}
