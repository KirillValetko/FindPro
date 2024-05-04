using FindPro.Web.Models.DtoModels;
using FluentValidation;

namespace FindPro.Web.Validators
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleForEach(e => e.EmployeeSkills).SetValidator(new EmployeeSkillDtoValidator());
        }
    }
}
