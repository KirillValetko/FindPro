using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Models;

namespace FindPro.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee, EmployeeDataModel, EmployeeFilter>
    {
    }
}
