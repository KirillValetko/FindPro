﻿namespace FindPro.DAL.Models
{
    public class SkillLevel : BaseDbModel
    {
        public string LevelName { get; set; }
        public int LevelValue { get; set; }
        public string Description { get; set; }
        public int GradeRevisionInMonths { get; set; }
        public bool IsUsed { get; set; }
        public Guid GroupId { get; set; }

        public SkillGroup SkillGroup { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
