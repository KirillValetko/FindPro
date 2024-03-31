using FindPro.BLL.Models;
using FindPro.Common.Models;
using FindPro.Web.Infrastructure.Mappers.Interfaces;
using FindPro.Web.Models.ViewModels;
using Riok.Mapperly.Abstractions;

namespace FindPro.Web.Infrastructure.Mappers
{
    [Mapper]
    public partial class SkillGroupWebMapper : ISkillGroupWebMapper
    {
        [MapperIgnoreSource(nameof(SkillGroupModel.IsUsed))]
        public partial SkillGroupViewModel Map(SkillGroupModel dbModel);

        public SkillGroupModel Map(SkillGroupViewModel dataModel)
        {
            throw new NotImplementedException();
        }

        public partial List<SkillGroupViewModel> Map(List<SkillGroupModel> dbModels);

        [MapperIgnoreSource(nameof(SkillGroupModel.IsUsed))]
        public List<SkillGroupModel> Map(List<SkillGroupViewModel> dataModels)
        {
            throw new NotImplementedException();
        }

        public void Map(SkillGroupViewModel dataModel, SkillGroupModel dbModel)
        {
            throw new NotImplementedException();
        }

        public partial PaginationResponse<SkillGroupViewModel> Map(PaginationResponse<SkillGroupModel> paginationResponse);
    }
}
