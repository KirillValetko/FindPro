using FluentValidation;
using FindPro.Web.Models.DtoModels;

namespace FindPro.Web.Validators
{
    public class SkillDtoValidator : AbstractValidator<SkillDto>
    {
        public SkillDtoValidator()
        {
            RuleFor(s => s.SkillName).NotEmpty();
            RuleFor(s => s.GroupId).NotEmpty();
        }
    }
}
