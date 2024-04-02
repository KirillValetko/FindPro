using FindPro.BLL.Infrastructure.Mappers.Interfaces;
using FindPro.BLL.Models;
using FindPro.Common.Models;
using FindPro.DAL.DataModels;
using Riok.Mapperly.Abstractions;

namespace FindPro.BLL.Infrastructure.Mappers
{
    [Mapper]
    public partial class SkillBllMapper : ISkillBllMapper
    {
        public partial SkillModel Map(SkillDataModel dataModel);

        public partial SkillDataModel Map(SkillModel model);

        public partial List<SkillModel> Map(List<SkillDataModel> dataModels);

        public partial List<SkillDataModel> Map(List<SkillModel> models);

        public void Map(SkillModel model, SkillDataModel dataModel)
        {
            throw new NotImplementedException();
        }

        public partial PaginationResponse<SkillModel> Map(PaginationResponse<SkillDataModel> paginationResponse);
    }
}
