﻿namespace FindPro.DAL.DataModels
{
    public class SkillGroupDataModel : BaseDataModel
    {
        public string GroupName { get; set; }
        public bool IsUsed { get; set; }

        public List<SkillLevelDataModel> SkillLevels { get; set; }
    }
}
