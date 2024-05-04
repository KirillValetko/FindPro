using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Models;

namespace FindPro.DAL.Repositories.Interfaces
{
    public interface ISkillLevelRepository : IBaseRepository<SkillLevel, SkillLevelDataModel, SkillLevelFilter>
    {
    }
}
