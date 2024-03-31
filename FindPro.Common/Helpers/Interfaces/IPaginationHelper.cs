using FindPro.Common.Models;

namespace FindPro.Common.Helpers.Interfaces
{
    public interface IPaginationHelper<T> where T : class
    {
        Task<PaginationResponse<T>> PaginateAsync(IQueryable<T> source, int? pageNumber, int? limit);
    }
}
