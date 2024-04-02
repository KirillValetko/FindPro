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
    public class SkillController : BaseController<SkillModel, SkillViewModel>
    {
        private readonly ISkillService _skillService;
        private readonly ISkillDtoMapper _skillDtoMapper;

        public SkillController(ISkillService skillService,
            ISkillDtoMapper skillDtoMapper,
            ISkillWebMapper mapper,
            ILogger<SkillController> logger) : base(mapper, logger)
        {
            _skillService = skillService;
            _skillDtoMapper = skillDtoMapper;
        }

        [HttpGet]
        public Task<IActionResult> GetAsync([FromQuery] PaginationRequest<SkillFilter> request)
        {
            return ProcessRequest(() => _skillService.GetPaginatedAsync(request));
        }

        [HttpPost]
        public Task<IActionResult> PostAsync(SkillDto item)
        {
            var mappedItem = _skillDtoMapper.Map(item);

            return ProcessRequest(() => _skillService.CreateAsync(mappedItem));
        }

        [HttpPut]
        public Task<IActionResult> PutAsync(SkillDto item)
        {
            var mappedItem = _skillDtoMapper.Map(item);

            return ProcessRequest(() => _skillService.UpdateAsync(mappedItem));
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteAsync(Guid id)
        {
            return ProcessRequest(() => _skillService.DeleteAsync(id));
        }
    }
}
