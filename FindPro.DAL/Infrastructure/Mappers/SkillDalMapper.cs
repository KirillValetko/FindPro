using FindPro.Common.Models;
using FindPro.DAL.DataModels;
using FindPro.DAL.Infrastructure.Mappers.Interfaces;
using FindPro.DAL.Models;
using Riok.Mapperly.Abstractions;

namespace FindPro.DAL.Infrastructure.Mappers
{
    [Mapper]
    public partial class SkillDalMapper : ISkillDalMapper
    {
        public partial SkillDataModel Map(Skill model);

        public partial Skill Map(SkillDataModel model);

        public partial List<SkillDataModel> Map(List<Skill> models);

        public partial List<Skill> Map(List<SkillDataModel> models);

        public partial void Map(SkillDataModel dataModel, Skill dbModel);

        public partial PaginationResponse<SkillDataModel> Map(PaginationResponse<Skill> paginationResponse);
    }
}
