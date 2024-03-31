using FindPro.Common.Models;
using FindPro.DAL.DataModels;
using FindPro.DAL.Infrastructure.Mappers.Interfaces;
using FindPro.DAL.Models;
using Riok.Mapperly.Abstractions;

namespace FindPro.DAL.Infrastructure.Mappers
{
    [Mapper]
    public partial class SkillGroupDalMapper : ISkillGroupDalMapper
    {
        public partial SkillGroupDataModel Map(SkillGroup dbModel);

        public partial SkillGroup Map(SkillGroupDataModel dataModel);

        public partial List<SkillGroupDataModel> Map(List<SkillGroup> dbModels);

        public partial List<SkillGroup> Map(List<SkillGroupDataModel> dataModels);

        public partial void Map(SkillGroupDataModel dataModel, SkillGroup dbModel);

        public partial PaginationResponse<SkillGroupDataModel> Map(PaginationResponse<SkillGroup> paginationResponse);
    }
}
