﻿using FindPro.BLL.Infrastructure.Mappers.Interfaces;
using FindPro.BLL.Models;
using FindPro.BLL.Services.Interfaces;
using FindPro.Common.Constants;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Models;
using FindPro.DAL.Repositories.Interfaces;

namespace FindPro.BLL.Services
{
    public class SkillGroupService :
        BaseService<SkillGroup, SkillGroupDataModel, SkillGroupModel, SkillGroupFilter>,
        ISkillGroupService
    {
        public SkillGroupService(ISkillGroupRepository repository,
            IUnitOfWork unitOfWork,
            ISkillGroupBllMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }

        public override async Task UpdateAsync(SkillGroupModel item)
        {
            var dbItem = await _repository.GetByFilterAsync(new SkillGroupFilter { Id = item.Id, IsTracking = true });

            if (dbItem is null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            var mappedSkillGroup = _mapper.Map(item);

            if (dbItem.IsUsed)
            {
                var skillLevels = new List<SkillLevelDataModel>();
                var skillLevelsToCreate = mappedSkillGroup.SkillLevels
                    .Where(skillLevel => skillLevel.Id.Equals(Guid.Empty))
                    .ToList();
                var skillLevelsToSoftDelete = dbItem.SkillLevels
                    .Where(skillLevel => skillLevel.IsUsed)
                    .ExceptBy(mappedSkillGroup.SkillLevels.Select(skillLevel => skillLevel.Id), skillLevel => skillLevel.Id)
                    .ToList();
                var skillLevelsToCheck = dbItem.SkillLevels
                    .IntersectBy(mappedSkillGroup.SkillLevels.Select(skillLevel => skillLevel.Id), skillLevel => skillLevel.Id)
                    .ToList();

                foreach (var srcSkillLevel in skillLevelsToCheck)
                {
                    var destSkillLevel = mappedSkillGroup.SkillLevels
                        .FirstOrDefault(skillLevel => skillLevel.Id.Equals(srcSkillLevel.Id));

                    if (srcSkillLevel.IsUsed)
                    {
                        if (srcSkillLevel.Equals(destSkillLevel))
                        {
                            skillLevelsToCreate.Add(srcSkillLevel);
                        }
                        else
                        {
                            skillLevelsToSoftDelete.Add(srcSkillLevel);
                            destSkillLevel!.Id = Guid.Empty;
                            skillLevelsToCreate.Add(destSkillLevel);
                        }
                    }
                    else
                    {
                        skillLevelsToCreate.Add(destSkillLevel);
                    }
                }

                skillLevels.AddRange(skillLevelsToCreate);
                skillLevelsToSoftDelete.ForEach(skillLevel => skillLevel.IsActive = false);
                skillLevels.AddRange(skillLevelsToSoftDelete);
                mappedSkillGroup.SkillLevels = skillLevels;
            }

            await _repository.UpdateAsync(mappedSkillGroup);
            await _unitOfWork.SaveAsync();
        }

        public override async Task DeleteAsync(Guid id)
        {
            var skillGroup = await _repository.GetByFilterAsync(new SkillGroupFilter { Id = id });

            if (skillGroup is null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            if (skillGroup.IsUsed)
            {
                await _repository.SoftDeleteAsync(id);
            }
            else
            {
                await _repository.HardDeleteAsync(id);
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
