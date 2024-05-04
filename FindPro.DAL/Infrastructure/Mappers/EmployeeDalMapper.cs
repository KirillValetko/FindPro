using FindPro.Common.Models;
using FindPro.DAL.DataModels;
using FindPro.DAL.Infrastructure.Mappers.Interfaces;
using FindPro.DAL.Models;
using Riok.Mapperly.Abstractions;

namespace FindPro.DAL.Infrastructure.Mappers
{
    [Mapper]
    public partial class EmployeeDalMapper : IEmployeeDalMapper
    {
        public partial EmployeeDataModel Map(Employee lowerLayerModel);

        public partial Employee Map(EmployeeDataModel topLayerModel);

        public partial List<EmployeeDataModel> Map(List<Employee> lowerLayerModels);

        public partial List<Employee> Map(List<EmployeeDataModel> topLayerModels);

        public partial void Map(EmployeeDataModel topLayerModel, Employee lowerLayerModel);

        public partial PaginationResponse<EmployeeDataModel> Map(PaginationResponse<Employee> paginationResponse);
    }
}
