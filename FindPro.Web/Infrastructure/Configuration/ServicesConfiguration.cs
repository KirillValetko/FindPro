using FindPro.BLL.Services;
using FindPro.BLL.Services.Interfaces;

namespace FindPro.Web.Infrastructure.Configuration
{
    public static class ServicesConfiguration
    {
        public static void InitServices(this IServiceCollection services)
        {
            services.AddScoped<ISkillGroupService, SkillGroupService>();
        }
    }
}
