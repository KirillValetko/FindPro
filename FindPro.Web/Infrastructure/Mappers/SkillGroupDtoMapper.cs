using FindPro.BLL.Models;
using FindPro.Common.Models;
using FindPro.Web.Infrastructure.Mappers.Interfaces;
using FindPro.Web.Models.DtoModels;
using Riok.Mapperly.Abstractions;

namespace FindPro.Web.Infrastructure.Mappers
{
    [Mapper]
    public partial class SkillGroupDtoMapper : ISkillGroupDtoMapper
    {
        public SkillGroupDto Map(SkillGroupModel model)
        {
            throw new NotImplementedException();
        }

        [MapperIgnoreTarget(nameof(SkillGroupModel.IsUsed))]
        public partial SkillGroupModel Map(SkillGroupDto dto);

        public List<SkillGroupDto> Map(List<SkillGroupModel> models)
        {
            throw new NotImplementedException();
        }

        public List<SkillGroupModel> Map(List<SkillGroupDto> dtos)
        {
            throw new NotImplementedException();
        }

        public void Map(SkillGroupDto dto, SkillGroupModel model)
        {
            throw new NotImplementedException();
        }

        public PaginationResponse<SkillGroupDto> Map(PaginationResponse<SkillGroupModel> paginationResponse)
        {
            throw new NotImplementedException();
        }
    }
}
