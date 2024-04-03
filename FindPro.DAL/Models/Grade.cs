using System.ComponentModel.DataAnnotations;

namespace FindPro.DAL.Models
{
    public class Grade : BaseDbModel
    {
        [DataType(DataType.Date)]
        public DateTime GradeDate { get; set; }
        public string Comment { get; set; }
        public Guid SkillLevelId { get; set; }
        public Guid EmployeeSkillId { get; set; }

        public SkillLevel SkillLevel { get; set; }
        public EmployeeSkill EmployeeSkill { get; set; }
    }
}
