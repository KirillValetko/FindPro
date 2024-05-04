using FindPro.BLL.Infrastructure.Mappers.Interfaces;
using FindPro.BLL.Models;
using FindPro.Common.Models;
using FindPro.DAL.DataModels;
using Riok.Mapperly.Abstractions;

namespace FindPro.BLL.Infrastructure.Mappers
{
    [Mapper]
    public partial class EmployeeBllMapper : IEmployeeBllMapper
    {
        public partial EmployeeModel Map(EmployeeDataModel dataModel);

        public partial EmployeeDataModel Map(EmployeeModel model);

        public partial List<EmployeeModel> Map(List<EmployeeDataModel> dataModels);

        public partial List<EmployeeDataModel> Map(List<EmployeeModel> models);

        public void Map(EmployeeModel model, EmployeeDataModel dataModel)
        {
            throw new NotImplementedException();
        }

        public partial PaginationResponse<EmployeeModel> Map(PaginationResponse<EmployeeDataModel> paginationResponse);
    }
}
