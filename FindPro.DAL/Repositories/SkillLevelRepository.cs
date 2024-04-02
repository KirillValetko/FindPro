using FindPro.Common.Helpers.Interfaces;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Infrastructure;
using FindPro.DAL.Models;
using FindPro.DAL.Repositories.Interfaces;
using FindPro.DAL.Infrastructure.Mappers.Interfaces;

namespace FindPro.DAL.Repositories
{
    public class SkillLevelRepository :
        BaseRepository<SkillLevel, SkillLevelDataModel, SkillLevelFilter>,
        ISkillLevelRepository
    {
        public SkillLevelRepository(FindProContext gradingContext,
            IPaginationHelper<SkillLevel> paginationHelper,
            ISkillLevelDataModelMapper mapper) : base(gradingContext, paginationHelper, mapper)
        {
        }

        protected override IQueryable<SkillLevel> AddFilterConditions(IQueryable<SkillLevel> items,
            SkillLevelFilter filter)
        {
            return items;
        }

        protected override void PrepareForCreation(SkillLevel item)
        {
            base.PrepareForCreation(item);
            item.IsUsed = false;
        }
    }
}
