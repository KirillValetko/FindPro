using FindPro.BLL.Infrastructure.Mappers;
using FindPro.BLL.Infrastructure.Mappers.Interfaces;
using FindPro.DAL.Infrastructure.Mappers;
using FindPro.DAL.Infrastructure.Mappers.Interfaces;
using FindPro.Web.Infrastructure.Mappers;
using FindPro.Web.Infrastructure.Mappers.Interfaces;

namespace FindPro.Web.Infrastructure.Configuration
{
    public static class MappersConfiguration
    {
        public static void InitMappers(this IServiceCollection services)
        {
            services.AddScoped<ISkillGroupDalMapper, SkillGroupDalMapper>();
            services.AddScoped<ISkillGroupBllMapper, SkillGroupBllMapper>();
            services.AddScoped<ISkillGroupDtoMapper, SkillGroupDtoMapper>();
            services.AddScoped<ISkillGroupWebMapper, SkillGroupWebMapper>();
        }
    }
}
