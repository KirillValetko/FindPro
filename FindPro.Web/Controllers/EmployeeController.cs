using FindPro.BLL.Models;
using FindPro.BLL.Services.Interfaces;
using FindPro.DAL.Filters;
using FindPro.Web.Infrastructure.Mappers.Interfaces;
using FindPro.Web.Models.DtoModels;
using FindPro.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FindPro.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<EmployeeModel, EmployeeViewModel>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeDtoMapper _employeeDtoMapper;

        public EmployeeController(IEmployeeService employeeService,
            IEmployeeDtoMapper employeeDtoMapper,
            IEmployeeWebMapper mapper,
            ILogger<EmployeeController> logger) : base(mapper, logger)
        {
            _employeeService = employeeService;
            _employeeDtoMapper = employeeDtoMapper;
        }

        [HttpGet]
        public Task<IActionResult> GetAsync([FromQuery] EmployeeFilter filter)
        {
            return ProcessRequest(() => _employeeService.GetAllByFilterAsync(filter));
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetAsync(Guid id)
        {
            return ProcessRequest(() => _employeeService.GetByFilterAsync(
                new EmployeeFilter { Id = id, IncludeEmployeeSkills = true }));
        }

        [HttpPut]
        public Task<IActionResult> PutAsync(EmployeeDto item)
        {
            var mappedItem = _employeeDtoMapper.Map(item);

            return ProcessRequest(() => _employeeService.UpdateAsync(mappedItem));
        }
    }
}
