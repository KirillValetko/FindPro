using Microsoft.EntityFrameworkCore;
using FindPro.Common.Helpers.Interfaces;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Infrastructure;
using FindPro.DAL.Models;
using FindPro.DAL.Repositories.Interfaces;
using FindPro.DAL.Infrastructure.Mappers.Interfaces;
using FindPro.Common.Constants;

namespace FindPro.DAL.Repositories
{
    public class EmployeeRepository :
        BaseRepository<Employee, EmployeeDataModel, EmployeeFilter>,
        IEmployeeRepository
    {
        public EmployeeRepository(FindProContext context,
            IPaginationHelper<Employee> paginationHelper,
            IEmployeeDalMapper mapper) : base(context, paginationHelper, mapper)
        {
        }

        public override void Create(EmployeeDataModel item)
        {
            var mappedItem = _mapper.Map(item);
            PrepareForCreation(mappedItem);
            SetStateForRelatedData(ref mappedItem);
            _context.Employees.Add(mappedItem);
        }

        public override async Task UpdateAsync(EmployeeDataModel item)
        {
            var dbItem = await _context.Employees
                .Include(employee => employee.EmployeeSkills)
                .AsSplitQuery()
                .FirstOrDefaultAsync(i => i.Id.Equals(item.Id));

            if (dbItem is null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            SaveImportantInfo(dbItem, item);
            _mapper.Map(item, dbItem);
            SetStateForRelatedData(ref dbItem);
        }

        protected override void PrepareForCreation(Employee item)
        {
            item.IsActive = true;
        }

        protected override IQueryable<Employee> AddFilterConditions(IQueryable<Employee> items, EmployeeFilter filter)
        {
            if (filter.GraderId.HasValue)
            {
                items = items.Where(employee => employee.GraderId.Equals(filter.GraderId));
            }

            if (filter.SkillIds is not null && filter.SkillIds.Count != 0) 
            {
                items = items
                    .Include(employee => employee.EmployeeSkills
                        .Where(employeeSkill => filter.SkillIds.Contains(employeeSkill.SkillId)))
                        .ThenInclude(employeeSkill => employeeSkill.Skill)
                    .OrderByDescending(employee => employee.EmployeeSkills.Count)
                    .AsSplitQuery();
            }

            if (filter.IncludeEmployeeSkills.HasValue && filter.IncludeEmployeeSkills.Value)
            {
                items = items
                    .Include(employee => employee.EmployeeSkills)
                        .ThenInclude(employeeSkill => employeeSkill.Grades.OrderByDescending(grade => grade.GradeDate))
                            .ThenInclude(grade => grade.SkillLevel)
                    .Include(employee => employee.EmployeeSkills)
                        .ThenInclude(employeeSkill => employeeSkill.Skill)
                            .ThenInclude(skill => skill.SkillGroup)
                                .ThenInclude(skillGroup => skillGroup.SkillLevels)
                    .AsSplitQuery();
            }

            return items;
        }

        private void SetStateForRelatedData(ref Employee item)
        {
            var skills = item.EmployeeSkills
                .Select(es => es.Skill);

            foreach (var skill in skills)
            {
                _context.Entry(skill).State = EntityState.Detached;
                _context.Entry(skill).State = EntityState.Modified;
            }

            var skillLevels = item.EmployeeSkills
                .SelectMany(es => es.Grades)
                .Select(g => g.SkillLevel)
                .DistinctBy(sl => sl.Id);

            foreach (var skillLevel in skillLevels)
            {
                _context.Entry(skillLevel).State = EntityState.Detached;
                _context.Entry(skillLevel).State = EntityState.Modified;
            }

            foreach (var employeeSkill in item.EmployeeSkills)
            {
                employeeSkill.Skill = null;

                foreach (var grade in employeeSkill.Grades)
                {
                    grade.SkillLevel = null;
                }
            }
        }
    }
}