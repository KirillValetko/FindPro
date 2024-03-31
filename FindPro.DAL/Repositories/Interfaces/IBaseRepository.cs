using FindPro.Common.Models;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Models;

namespace FindPro.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel, TDataModel, TFilter>
        where TDbModel : BaseDbModel
        where TDataModel : BaseDataModel
        where TFilter : BaseFilter
    {
        void Create(TDataModel item);
        void CreateMany(List<TDataModel> items);
        Task UpdateAsync(TDataModel item);
        Task UpdateManyAsync(List<TDataModel> items);
        Task SoftDeleteAsync(Guid id);
        Task SoftDeleteManyAsync(List<Guid> ids);
        Task HardDeleteAsync(Guid id);
        Task HardDeleteManyAsync(List<Guid> ids);
        Task<TDataModel> GetByFilterAsync(TFilter filter);
        Task<List<TDataModel>> GetAllByFilterAsync(TFilter filter);
        Task<PaginationResponse<TDataModel>> GetPaginatedAsync(PaginationRequest<TFilter> request);
    }
}
