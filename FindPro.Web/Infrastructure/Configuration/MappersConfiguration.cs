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

            services.AddScoped<ISkillLevelDalMapper, SkillLevelDalMapper>();

            services.AddScoped<ISkillDalMapper, SkillDalMapper>();
            services.AddScoped<ISkillBllMapper, SkillBllMapper>();
            services.AddScoped<ISkillDtoMapper, SkillDtoMapper>();
            services.AddScoped<ISkillWebMapper, SkillWebMapper>();

            services.AddScoped<IEmployeeDalMapper, EmployeeDalMapper>();
            services.AddScoped<IEmployeeBllMapper, EmployeeBllMapper>();
            services.AddScoped<IEmployeeDtoMapper, EmployeeDtoMapper>();
            services.AddScoped<IEmployeeWebMapper, EmployeeWebMapper>();
        }
    }
}
