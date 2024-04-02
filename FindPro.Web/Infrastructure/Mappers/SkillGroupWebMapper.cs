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
        public partial SkillGroupViewModel Map(SkillGroupModel model);

        public SkillGroupModel Map(SkillGroupViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public partial List<SkillGroupViewModel> Map(List<SkillGroupModel> models);

        public List<SkillGroupModel> Map(List<SkillGroupViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public void Map(SkillGroupViewModel viewModel, SkillGroupModel model)
        {
            throw new NotImplementedException();
        }

        public partial PaginationResponse<SkillGroupViewModel> Map(PaginationResponse<SkillGroupModel> paginationResponse);
    }
}
