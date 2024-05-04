using FindPro.BLL.Models;
using FindPro.Common.Models;
using FindPro.Web.Infrastructure.Mappers.Interfaces;
using FindPro.Web.Models.DtoModels;
using Riok.Mapperly.Abstractions;

namespace FindPro.Web.Infrastructure.Mappers
{
    [Mapper]
    public partial class EmployeeDtoMapper : IEmployeeDtoMapper
    {

        public EmployeeDto Map(EmployeeModel model)
        {
            throw new NotImplementedException();
        }

        public partial EmployeeModel Map(EmployeeDto dto);

        public List<EmployeeDto> Map(List<EmployeeModel> models)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> Map(List<EmployeeDto> dtos)
        {
            throw new NotImplementedException();
        }
        
        public void Map(EmployeeDto dto, EmployeeModel model)
        {
            throw new NotImplementedException();
        }

        public PaginationResponse<EmployeeDto> Map(PaginationResponse<EmployeeModel> paginationResponse)
        {
            throw new NotImplementedException();
        }
    }
}
