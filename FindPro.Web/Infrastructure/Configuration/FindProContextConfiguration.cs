using Microsoft.EntityFrameworkCore;
using FindPro.DAL.Infrastructure;

namespace SkillsGrading.Web.Infrastructure.Configuration
{
    public static class FindProContextConfiguration
    {
        private const string ConnectionString = "ConnectionStrings:FindProDB";
        public static void InitDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FindProContext>(opt =>
                opt.UseSqlServer(configuration[ConnectionString]));
        }
    }
}
