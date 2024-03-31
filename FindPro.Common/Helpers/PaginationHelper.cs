using Microsoft.EntityFrameworkCore;
using FindPro.Common.Constants;
using FindPro.Common.Helpers.Interfaces;
using FindPro.Common.Models;

namespace FindPro.Common.Helpers
{
    public class PaginationHelper<T> : IPaginationHelper<T> where T : class
    {
        public async Task<PaginationResponse<T>> PaginateAsync(IQueryable<T> source, int? pageNumber, int? limit)
        {
            if (pageNumber is not > 0)
            {
                pageNumber = PaginationDefaultConstants.PageNumber;
            }

            if (limit is not > 0)
            {
                limit = PaginationDefaultConstants.Limit;
            }

            var itemCount = await source.CountAsync();
            var pageCount = (int)Math.Ceiling((double)itemCount / limit.Value);
            var paginatedItems = await source.Skip(limit.Value*(pageNumber.Value - 1)).Take(limit.Value).ToListAsync();

            var response = new PaginationResponse<T>
            {
                CurrentPage = pageNumber.Value,
                PageCount = pageCount,
                PaginatedData = paginatedItems
            };

            return response;
        }
    }
}
