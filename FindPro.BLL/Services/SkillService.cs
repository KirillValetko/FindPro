using FindPro.BLL.Infrastructure.Mappers.Interfaces;
using FindPro.BLL.Models;
using FindPro.BLL.Services.Interfaces;
using FindPro.Common.Constants;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Models;
using FindPro.DAL.Repositories.Interfaces;

namespace FindPro.BLL.Services
{
    public class SkillService :
        BaseService<Skill, SkillDataModel, SkillModel, SkillFilter>,
        ISkillService
    {
        private readonly ISkillGroupRepository _skillGroupRepository;

        public SkillService(ISkillRepository repository,
            ISkillGroupRepository skillGroupRepository,
            IUnitOfWork unitOfWork,
            ISkillBllMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _skillGroupRepository = skillGroupRepository;
        }

        public override async Task CreateAsync(SkillModel item)
        {
            var skillGroup = await _skillGroupRepository.GetByFilterAsync(
                new SkillGroupFilter { Id = item.GroupId });

            if (skillGroup == null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            var mappedItem = _mapper.Map(item);
            mappedItem.SkillGroup = skillGroup;
            _repository.Create(mappedItem);
            await _unitOfWork.SaveAsync();
        }

        public override async Task UpdateAsync(SkillModel item)
        {
            var dbItem = await _repository.GetByFilterAsync(
                new SkillFilter { Id = item.Id, IncludeSkillGroup = false });

            if (dbItem is null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            var mappedItem = _mapper.Map(item);
            var skillGroup = await _skillGroupRepository.GetByFilterAsync(
                new SkillGroupFilter { Id = item.GroupId, IncludeSkillLevels = false });

            if (skillGroup is null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            mappedItem.SkillGroup = skillGroup;

            if (dbItem.IsUsed)
            {
                await _repository.SoftDeleteAsync(mappedItem.Id);
                _repository.Create(mappedItem);
            }
            else
            {
                await _repository.UpdateAsync(mappedItem);
            }

            await _unitOfWork.SaveAsync();
        }

        public override async Task DeleteAsync(Guid id)
        {
            var dbItem = await _repository.GetByFilterAsync(
                new SkillFilter { Id = id });

            if (dbItem is null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            if (dbItem.IsUsed)
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
