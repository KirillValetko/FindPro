﻿namespace FindPro.Web.Models.ViewModels
{
    public class SkillLevelViewModel : BaseWebModel
    {
        public string LevelName { get; set; }
        public int LevelValue { get; set; }
        public string Description { get; set; }
        public int GradeRevisionInMonths { get; set; }
    }
}
