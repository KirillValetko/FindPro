using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using FindPro.BLL.Responses;
using FindPro.Common.Interfaces;
using FindPro.Common.Models;

namespace FindPro.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TModel, TViewModel> : ControllerBase
        where TModel : class
        where TViewModel : class
    {
        protected readonly IBaseMapper<TModel, TViewModel> _mapper;
        protected readonly ILogger<BaseController<TModel, TViewModel>> _logger;

        protected BaseController(IBaseMapper<TModel, TViewModel> mapper,
            ILogger<BaseController<TModel, TViewModel>> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        protected async Task<IActionResult> ProcessRequest(Func<Task<PaginationResponse<TModel>>> func)
        {
            try
            {
                var result = await func();
                var mappedResult = _mapper.Map(result);

                return Ok(new ApiResponse<PaginationResponse<TViewModel>>(mappedResult));
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.Message);
                Console.WriteLine(ex.Message);

                return BadRequest(new ApiResponse<TViewModel>(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                Console.WriteLine(ex.Message);

                return BadRequest(new ApiResponse<TViewModel>(ex.Message));
            }
        }

        protected async Task<IActionResult> ProcessRequest(Func<Task<List<TModel>>> func)
        {
            try
            {
                var result = await func();
                var mappedResult = _mapper.Map(result);

                return Ok(new ApiResponse<List<TViewModel>>(mappedResult));
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.Message);
                Console.WriteLine(ex.Message);

                return BadRequest(new ApiResponse<TViewModel>(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                Console.WriteLine(ex.Message);

                return BadRequest(new ApiResponse<TViewModel>(ex.Message));
            }
        }

        protected async Task<IActionResult> ProcessRequest(Func<Task> func)
        {
            try
            {
                await func();

                return Ok(new ApiResponse<TViewModel>(default(TViewModel)));
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.Message);
                Console.WriteLine(ex.Message);

                return BadRequest(new ApiResponse<TViewModel>(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                Console.WriteLine(ex.Message);

                return BadRequest(new ApiResponse<TViewModel>(ex.Message));
            }
        }
    }
}
