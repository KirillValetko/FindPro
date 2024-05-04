using FindPro.Common.Helpers.Interfaces;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Infrastructure;
using FindPro.DAL.Infrastructure.Mappers.Interfaces;
using FindPro.DAL.Models;
using FindPro.DAL.Repositories.Interfaces;

namespace FindPro.DAL.Repositories
{
    public class SkillLevelRepository :
        BaseRepository<SkillLevel, SkillLevelDataModel, SkillLevelFilter>,
        ISkillLevelRepository
    {
        public SkillLevelRepository(FindProContext context,
            IPaginationHelper<SkillLevel> paginationHelper,
            ISkillLevelDalMapper mapper) : base(context, paginationHelper, mapper)
        {
        }

        protected override IQueryable<SkillLevel> AddFilterConditions(IQueryable<SkillLevel> items, SkillLevelFilter filter)
        {
            return items;
        }
    }
}
