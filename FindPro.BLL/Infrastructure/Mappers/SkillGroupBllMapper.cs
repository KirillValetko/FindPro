using FindPro.BLL.Infrastructure.Mappers.Interfaces;
using FindPro.BLL.Models;
using FindPro.Common.Models;
using FindPro.DAL.DataModels;
using Riok.Mapperly.Abstractions;

namespace FindPro.BLL.Infrastructure.Mappers
{
    [Mapper]
    public partial class SkillGroupBllMapper : ISkillGroupBllMapper
    {
        public partial SkillGroupModel Map(SkillGroupDataModel dataModel);

        public partial SkillGroupDataModel Map(SkillGroupModel model);

        public partial List<SkillGroupModel> Map(List<SkillGroupDataModel> dataModels);

        public partial List<SkillGroupDataModel> Map(List<SkillGroupModel> models);

        public void Map(SkillGroupModel model, SkillGroupDataModel dataModel)
        {
            throw new NotImplementedException();
        }

        public partial PaginationResponse<SkillGroupModel> Map(PaginationResponse<SkillGroupDataModel> paginationResponse);
    }
}
