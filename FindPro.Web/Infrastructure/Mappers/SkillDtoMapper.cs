using FindPro.BLL.Models;
using FindPro.Common.Models;
using FindPro.Web.Infrastructure.Mappers.Interfaces;
using FindPro.Web.Models.DtoModels;
using Riok.Mapperly.Abstractions;

namespace FindPro.Web.Infrastructure.Mappers
{
    [Mapper]
    public partial class SkillDtoMapper : ISkillDtoMapper
    {
        public SkillDto Map(SkillModel model)
        {
            throw new NotImplementedException();
        }

        public partial SkillModel Map(SkillDto dto);

        public List<SkillDto> Map(List<SkillModel> models)
        {
            throw new NotImplementedException();
        }

        public List<SkillModel> Map(List<SkillDto> dtos)
        {
            throw new NotImplementedException();
        }

        public void Map(SkillDto dto, SkillModel model)
        {
            throw new NotImplementedException();
        }

        public PaginationResponse<SkillDto> Map(PaginationResponse<SkillModel> paginationResponse)
        {
            throw new NotImplementedException();
        }
    }
}
