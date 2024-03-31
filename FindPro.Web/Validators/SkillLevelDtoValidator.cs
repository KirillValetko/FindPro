using FluentValidation;
using FindPro.Web.Models.DtoModels;

namespace FindPro.Web.Validators
{
    public class SkillLevelDtoValidator : AbstractValidator<SkillLevelDto>
    {
        public SkillLevelDtoValidator()
        {
            RuleFor(sl => sl.LevelName).NotEmpty();
            RuleFor(sl => sl.LevelValue).GreaterThan(0).NotEmpty();
            RuleFor(sl => sl.Description).NotEmpty();
        }
    }
}
