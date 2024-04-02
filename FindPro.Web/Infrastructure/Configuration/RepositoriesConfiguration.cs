using FindPro.DAL.Repositories;
using FindPro.DAL.Repositories.Interfaces;

namespace FindPro.Web.Infrastructure.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static void InitRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISkillGroupRepository, SkillGroupRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
