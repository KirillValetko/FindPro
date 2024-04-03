using Microsoft.EntityFrameworkCore;
using FindPro.Common.Helpers.Interfaces;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Infrastructure;
using FindPro.DAL.Models;
using FindPro.DAL.Repositories.Interfaces;
using FindPro.DAL.Infrastructure.Mappers.Interfaces;

namespace FindPro.DAL.Repositories
{
    public class SkillRepository :
        BaseRepository<Skill, SkillDataModel, SkillFilter>,
        ISkillRepository
    {
        private readonly ISkillGroupDalMapper _skillGroupMapper;

        public SkillRepository(FindProContext gradingContext,
            IPaginationHelper<Skill> paginationHelper,
            ISkillDalMapper mapper,
            ISkillGroupDalMapper skillGroupMapper) : base(gradingContext, paginationHelper, mapper)
        {
            _skillGroupMapper = skillGroupMapper;
        }

        protected override IQueryable<Skill> AddFilterConditions(IQueryable<Skill> items, SkillFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.SkillName))
            {
                items = items.Where(skill => skill.SkillName.Contains(filter.SkillName));
            }

            if (!filter.IncludeSkillGroup.HasValue || filter.IncludeSkillGroup.Value)
            {
                items = items.Include(skill => skill.SkillGroup)
                    .ThenInclude(skillGroup => skillGroup.SkillLevels
                        .Where(skillLevel => skillLevel.IsActive)
                        .OrderBy(skillLevel => skillLevel.LevelValue));
            }

            return items;
        }

        protected override void SaveImportantInfo(Skill beforeSave, SkillDataModel forSave)
        {
            base.SaveImportantInfo(beforeSave, forSave);
            forSave.IsUsed = beforeSave.IsUsed;
            forSave.SkillGroup.IsUsed = true;
        }

        protected override void PrepareForCreation(Skill item)
        {
            base.PrepareForCreation(item);
            item.IsUsed = false;
            item.SkillGroup.IsUsed = true;
            _context.Entry(item.SkillGroup).State = EntityState.Modified;
        }
    }
}
