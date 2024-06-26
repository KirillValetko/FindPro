﻿namespace FindPro.DAL.Models
{
    public class Skill : BaseDbModel
    {
        public string SkillName { get; set; }
        public bool IsUsed { get; set; }
        public Guid GroupId { get; set; }

        public SkillGroup SkillGroup { get; set; }
        public List<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
