using FindPro.BLL.Models;
using FindPro.Common.Models;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Models;

namespace FindPro.BLL.Services.Interfaces
{
    public interface IBaseService<TDbModel, TDataModel, TModel, TFilter>
        where TDbModel : BaseDbModel
        where TDataModel : BaseDataModel
        where TModel : BaseModel
        where TFilter : BaseFilter
    {
        Task CreateAsync(TModel item);
        Task UpdateAsync(TModel item);
        Task DeleteAsync(Guid id);
        Task<TModel> GetByFilterAsync(TFilter filter);
        Task<List<TModel>> GetAllByFilterAsync(TFilter filter);
        Task<PaginationResponse<TModel>> GetPaginatedAsync(PaginationRequest<TFilter> request);
    }
}
