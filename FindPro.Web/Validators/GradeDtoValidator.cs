using FindPro.Web.Models.DtoModels;
using FluentValidation;

namespace FindPro.Web.Validators
{
    public class GradeDtoValidator : AbstractValidator<GradeDto>
    {
        public GradeDtoValidator()
        {
            RuleFor(g => g.Comment).NotEmpty();
            RuleFor(g => g.SkillLevelId).NotEmpty();
        }
    }
}
