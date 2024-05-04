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
    public class EmployeeService :
        BaseService<Employee, EmployeeDataModel, EmployeeModel, EmployeeFilter>,
        IEmployeeService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly ISkillLevelRepository _skillLevelRepository;

        public EmployeeService(IEmployeeRepository repository,
            ISkillRepository skillRepository,
            ISkillLevelRepository skillLevelRepository,
            IUnitOfWork unitOfWork,
            IEmployeeBllMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _skillRepository = skillRepository;
            _skillLevelRepository = skillLevelRepository;
        }

        public override async Task UpdateAsync(EmployeeModel item)
        {
            var skillsIds = item.EmployeeSkills
                .Select(es => es.SkillId)
                .ToList();
            var dbSkills = await _skillRepository.GetAllByFilterAsync(
                new SkillFilter { Ids = skillsIds, OnlyActive = false, IncludeSkillGroup = false });

            if (skillsIds.Count != dbSkills.Count)
            {
                throw new Exception(ExceptionMessageConstants.WrongIds);
            }

            var skillLevelsIds = item.EmployeeSkills
                .SelectMany(es => es.Grades)
                .Select(g => g.SkillLevelId)
                .Distinct()
                .ToList();
            var dbSkillLevels = await _skillLevelRepository.GetAllByFilterAsync(
                new SkillLevelFilter { Ids = skillLevelsIds, OnlyActive = false });

            if (skillLevelsIds.Count != 0 && skillLevelsIds.Count != dbSkillLevels.Count)
            {
                throw new Exception(ExceptionMessageConstants.WrongIds);
            }

            var mappedItem = _mapper.Map(item);

            foreach (var employeeSkill in mappedItem.EmployeeSkills)
            {
                var skill = dbSkills.FirstOrDefault(s => s.Id.Equals(employeeSkill.SkillId));
                skill.IsUsed = true;
                employeeSkill.Skill = skill;
                employeeSkill.IsActive = true;
            }

            foreach (var grade in mappedItem.EmployeeSkills.SelectMany(es => es.Grades))
            {
                var skillLevel = dbSkillLevels.FirstOrDefault(sl => sl.Id.Equals(grade.SkillLevelId));
                skillLevel.IsUsed = true;
                grade.SkillLevel = skillLevel;
                grade.IsActive = true;

                if (grade.Id.Equals(Guid.Empty)) 
                {
                    grade.GradeDate = DateTime.Now;
                }
            }

            var dbItem = await _repository.GetByFilterAsync(
                new EmployeeFilter { Id = item.Id, IncludeEmployeeSkills = true });

            if (dbItem is null)
            {
                _repository.Create(mappedItem);
            }
            else
            {
                var employeeSkillsIds = item.EmployeeSkills
                    .Where(es => !es.Id.Equals(Guid.Empty))
                    .Select(es => es.Id);
                var dbEmployeeSkillsIds = dbItem.EmployeeSkills
                    .Select(es => es.Id);

                if (employeeSkillsIds.Count() > dbEmployeeSkillsIds.Count())
                {
                    throw new Exception(ExceptionMessageConstants.WrongIds);
                }
                
                var gradesIds = item.EmployeeSkills
                    .SelectMany(es => es.Grades)
                    .Where(g => !g.Id.Equals(Guid.Empty))
                    .Select(g => g.Id);
                var dbGradesIds = item.EmployeeSkills
                    .SelectMany(es => es.Grades)
                    .Select(g => g.Id);

                if (gradesIds.Count() > dbGradesIds.Count())
                {
                    throw new Exception(ExceptionMessageConstants.WrongIds);
                }

                await _repository.UpdateAsync(mappedItem);
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
