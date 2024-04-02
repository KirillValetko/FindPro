using FindPro.BLL.Models;
using FindPro.Common.Models;
using FindPro.Web.Infrastructure.Mappers.Interfaces;
using FindPro.Web.Models.ViewModels;
using Riok.Mapperly.Abstractions;

namespace FindPro.Web.Infrastructure.Mappers
{
    [Mapper]
    public partial class SkillWebMapper : ISkillWebMapper
    {
        public partial SkillViewModel Map(SkillModel model);

        public SkillModel Map(SkillViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public partial List<SkillViewModel> Map(List<SkillModel> models);

        public List<SkillModel> Map(List<SkillViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public void Map(SkillViewModel viewModel, SkillModel model)
        {
            throw new NotImplementedException();
        }

        public partial PaginationResponse<SkillViewModel> Map(PaginationResponse<SkillModel> paginationResponse);
    }
}
