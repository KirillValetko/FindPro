using FluentValidation;
using FindPro.Web.Models.DtoModels;

namespace FindPro.Web.Validators
{
    public class SkillGroupDtoValidator : AbstractValidator<SkillGroupDto>
    {
        public SkillGroupDtoValidator()
        {
            RuleFor(sg => sg.GroupName).NotEmpty();
            RuleFor(sg => sg.SkillLevels).NotEmpty();
            RuleForEach(sg => sg.SkillLevels).SetValidator(new SkillLevelDtoValidator());
        }
    }
}
