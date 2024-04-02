using FindPro.Common.Helpers;
using FindPro.Common.Helpers.Interfaces;
using FindPro.DAL.Models;

namespace FindPro.Web.Infrastructure.Configuration
{
    public static class HelpersConfiguration
    {
        public static void InitHelpers(this IServiceCollection services)
        {
            services.AddScoped<IPaginationHelper<SkillGroup>, PaginationHelper<SkillGroup>>();
            services.AddScoped<IPaginationHelper<Skill>, PaginationHelper<Skill>>();
        }
    }
}
