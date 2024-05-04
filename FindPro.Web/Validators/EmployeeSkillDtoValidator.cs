using FindPro.Web.Models.DtoModels;
using FluentValidation;

namespace FindPro.Web.Validators
{
    public class EmployeeSkillDtoValidator : AbstractValidator<EmployeeSkillDto>
    {
        public EmployeeSkillDtoValidator()
        {
            RuleFor(es => es.SkillId).NotEmpty();
            RuleForEach(es => es.Grades).SetValidator(new GradeDtoValidator());
        }
    }
}
