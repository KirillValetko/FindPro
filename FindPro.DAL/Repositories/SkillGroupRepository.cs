using Microsoft.EntityFrameworkCore;
using FindPro.Common.Constants;
using FindPro.Common.Helpers.Interfaces;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Models;
using FindPro.DAL.Repositories.Interfaces;
using FindPro.DAL.Infrastructure;
using FindPro.DAL.Infrastructure.Mappers.Interfaces;

namespace FindPro.DAL.Repositories
{
    public class SkillGroupRepository :
        BaseRepository<SkillGroup, SkillGroupDataModel, SkillGroupFilter>,
        ISkillGroupRepository
    {
        public SkillGroupRepository(FindProContext context,
            IPaginationHelper<SkillGroup> paginationHelper,
            ISkillGroupDalMapper mapper) : base(context, paginationHelper, mapper)
        {
        }

        public override async Task SoftDeleteAsync(Guid id)
        {
            var dbItem = await _context.SkillGroups
                .Include(skillGroup => skillGroup.SkillLevels
                    .Where(skillLevel => skillLevel.IsActive))
                .FirstOrDefaultAsync(i => i.Id.Equals(id));

            if (dbItem == null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            dbItem.IsActive = false;
            dbItem.SkillLevels.ForEach(skillLevel => skillLevel.IsActive = false);
        }

        protected override IQueryable<SkillGroup> AddFilterConditions(IQueryable<SkillGroup> items,
            SkillGroupFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.GroupName))
            {
                items = items.Where(skillGroup => skillGroup.GroupName.Contains(filter.GroupName));
            }

            items = items.Include(group => 
                group.SkillLevels
                .Where(skillLevel => skillLevel.IsActive && skillLevel.LevelValue != 0)
                .OrderBy(skillLevel => skillLevel.LevelValue));

            return items;
        }

        protected override void PrepareForCreation(SkillGroup item)
        {
            base.PrepareForCreation(item);
            item.IsUsed = false;
            
            foreach (var skillLevel in item.SkillLevels)
            {
                skillLevel.Id = Guid.NewGuid();
                skillLevel.IsActive = true;
                skillLevel.IsUsed = false;
            }
        }

        protected override void SaveImportantInfo(SkillGroup beforeSave, SkillGroupDataModel forSave)
        {
            base.SaveImportantInfo(beforeSave, forSave);
            forSave.IsUsed = beforeSave.IsUsed;
        }
    }
}
