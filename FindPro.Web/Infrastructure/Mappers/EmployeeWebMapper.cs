using FindPro.BLL.Models;
using FindPro.Common.Models;
using FindPro.Web.Infrastructure.Mappers.Interfaces;
using FindPro.Web.Models.ViewModels;
using Riok.Mapperly.Abstractions;

namespace FindPro.Web.Infrastructure.Mappers
{
    [Mapper]
    public partial class EmployeeWebMapper : IEmployeeWebMapper
    {
        public partial EmployeeViewModel Map(EmployeeModel lowerLayerModel);

        public EmployeeModel Map(EmployeeViewModel topLayerModel)
        {
            throw new NotImplementedException();
        }

        public partial List<EmployeeViewModel> Map(List<EmployeeModel> lowerLayerModels);

        public List<EmployeeModel> Map(List<EmployeeViewModel> topLayerModels)
        {
            throw new NotImplementedException();
        }

        public void Map(EmployeeViewModel topLayerModel, EmployeeModel lowerLayerModel)
        {
            throw new NotImplementedException();
        }

        public partial PaginationResponse<EmployeeViewModel> Map(PaginationResponse<EmployeeModel> paginationResponse);
    }
}
