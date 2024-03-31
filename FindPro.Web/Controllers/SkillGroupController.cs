using Microsoft.AspNetCore.Mvc;
using FindPro.BLL.Models;
using FindPro.BLL.Services.Interfaces;
using FindPro.Common.Models;
using FindPro.DAL.Filters;
using FindPro.Web.Models.DtoModels;
using FindPro.Web.Models.ViewModels;
using FindPro.Web.Infrastructure.Mappers.Interfaces;

namespace FindPro.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillGroupController : BaseController<SkillGroupModel, SkillGroupViewModel>
    {
        private readonly ISkillGroupService _skillGroupService;
        private readonly ISkillGroupDtoMapper _skillGroupDtoMapper;

        public SkillGroupController(ISkillGroupService skillGroupService,
            ISkillGroupDtoMapper skillGroupDtoMapper,
            ISkillGroupWebMapper mapper,
            ILogger<SkillGroupController> logger) : base(mapper, logger)
        {
            _skillGroupService = skillGroupService;
            _skillGroupDtoMapper = skillGroupDtoMapper;
        }

        [HttpGet]
        public Task<IActionResult> GetAsync([FromQuery] PaginationRequest<SkillGroupFilter> request)
        {
            return ProcessRequest(() => _skillGroupService.GetPaginatedAsync(request));
        }

        [HttpPost]
        public Task<IActionResult> PostAsync(SkillGroupDto item)
        {
            var mappedItem = _skillGroupDtoMapper.Map(item);

            return ProcessRequest(() => _skillGroupService.CreateAsync(mappedItem));
        }

        [HttpPut]
        public Task<IActionResult> PutAsync(SkillGroupDto item)
        {
            var mappedItem = _skillGroupDtoMapper.Map(item);

            return ProcessRequest(() => _skillGroupService.UpdateAsync(mappedItem));
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteAsync(Guid id)
        {
            return ProcessRequest(() => _skillGroupService.DeleteAsync(id));
        }
    }
}
