using FindPro.BLL.Models;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Models;

namespace FindPro.BLL.Services.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee, EmployeeDataModel, EmployeeModel, EmployeeFilter>
    {
    }
}
