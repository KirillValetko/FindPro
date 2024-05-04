using FindPro.Common.Models;
using FindPro.DAL.DataModels;
using FindPro.DAL.Infrastructure.Mappers.Interfaces;
using FindPro.DAL.Models;
using Riok.Mapperly.Abstractions;

namespace FindPro.DAL.Infrastructure.Mappers
{
    [Mapper]
    public partial class SkillLevelDalMapper : ISkillLevelDalMapper
    {
        public partial SkillLevelDataModel Map(SkillLevel lowerLayerModel);

        public SkillLevel Map(SkillLevelDataModel topLayerModel)
        {
            throw new NotImplementedException();
        }

        public partial List<SkillLevelDataModel> Map(List<SkillLevel> lowerLayerModels);

        public List<SkillLevel> Map(List<SkillLevelDataModel> topLayerModels)
        {
            throw new NotImplementedException();
        }

        public void Map(SkillLevelDataModel topLayerModel, SkillLevel lowerLayerModel)
        {
            throw new NotImplementedException();
        }

        public PaginationResponse<SkillLevelDataModel> Map(PaginationResponse<SkillLevel> paginationResponse)
        {
            throw new NotImplementedException();
        }
    }
}
