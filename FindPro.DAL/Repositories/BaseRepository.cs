using FindPro.DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using FindPro.Common.Constants;
using FindPro.Common.Helpers.Interfaces;
using FindPro.Common.Models;
using FindPro.DAL.DataModels;
using FindPro.DAL.Filters;
using FindPro.DAL.Models;
using FindPro.DAL.Repositories.Interfaces;
using FindPro.Common.Interfaces;

namespace FindPro.DAL.Repositories
{
    public abstract class BaseRepository<TDbModel, TDataModel, TFilter> : 
        IBaseRepository<TDbModel, TDataModel, TFilter>
        where TDbModel : BaseDbModel
        where TDataModel : BaseDataModel
        where TFilter : BaseFilter, new()
    {
        protected readonly FindProContext _context;
        protected readonly IPaginationHelper<TDbModel> _paginationHelper;
        protected readonly IBaseMapper<TDbModel, TDataModel> _mapper;

        protected BaseRepository(FindProContext context,
            IPaginationHelper<TDbModel> paginationHelper,
            IBaseMapper<TDbModel, TDataModel> mapper)
        {
            _context = context;
            _paginationHelper = paginationHelper;
            _mapper = mapper;
        }

        public virtual void Create(TDataModel item)
        {
            var mappedItem = _mapper.Map(item);
            PrepareForCreation(mappedItem);
            _context.Set<TDbModel>().Add(mappedItem);
        }

        public virtual void CreateMany(List<TDataModel> items)
        {
            var mappedItems = _mapper.Map(items);
            mappedItems.ForEach(PrepareForCreation);
            _context.Set<TDbModel>().AddRange(mappedItems);
        }

        public virtual async Task UpdateAsync(TDataModel item)
        {
            var dbItem = await _context.Set<TDbModel>().FirstOrDefaultAsync(i => i.Id.Equals(item.Id));

            if (dbItem is null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }
            
            SaveImportantInfo(dbItem, item);
            _mapper.Map(item, dbItem);
        }

        public virtual async Task UpdateManyAsync(List<TDataModel> items)
        {
            var itemIds = items.Select(i => i.Id).ToList();
            var dbItems = await _context.Set<TDbModel>().Where(i => itemIds.Contains(i.Id)).ToListAsync();

            if (itemIds.Count != dbItems.Count)
            {
                throw new Exception(ExceptionMessageConstants.EntitiesAreNotFound);
            }

            foreach (var item in items)
            {
                var dbItem = dbItems.FirstOrDefault(i => i.Id.Equals(item.Id));
                SaveImportantInfo(dbItem, item);
                _mapper.Map(item, dbItem);
            }
        }

        public virtual async Task SoftDeleteAsync(Guid id)
        {
            var dbItem = await _context.Set<TDbModel>().FirstOrDefaultAsync(i => i.Id.Equals(id));

            if (dbItem is null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            dbItem.IsActive = false;
        }

        public virtual async Task SoftDeleteManyAsync(List<Guid> ids)
        {
            var dbItems = await _context.Set<TDbModel>().Where(i => ids.Contains(i.Id)).ToListAsync();

            if (ids.Count != dbItems.Count)
            {
                throw new Exception(ExceptionMessageConstants.EntitiesAreNotFound);
            }

            dbItems.ForEach(i => i.IsActive = false);
        }

        public virtual async Task HardDeleteAsync(Guid id)
        {
            var dbItem = await _context.Set<TDbModel>().FirstOrDefaultAsync(i => i.Id.Equals(id));

            if (dbItem is null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            _context.Set<TDbModel>().Remove(dbItem);
        }

        public virtual async Task HardDeleteManyAsync(List<Guid> ids)
        {
            var dbItems = await _context.Set<TDbModel>().Where(i => ids.Contains(i.Id)).ToListAsync();

            if (ids.Count != dbItems.Count)
            {
                throw new Exception(ExceptionMessageConstants.EntitiesAreNotFound);
            }

            _context.Set<TDbModel>().RemoveRange(dbItems);
        }

        public async Task<TDataModel> GetByFilterAsync(TFilter filter)
        {
            var source = ConstructFilter(filter);

            var item = await source.FirstOrDefaultAsync();
            var mappedItem = _mapper.Map(item);

            return mappedItem;
        }

        public async Task<List<TDataModel>> GetAllByFilterAsync(TFilter filter)
        {
            var source = ConstructFilter(filter);

            var items = await source.ToListAsync();
            var mappedItems = _mapper.Map(items);

            return mappedItems;
        }

        public async Task<PaginationResponse<TDataModel>> GetPaginatedAsync(PaginationRequest<TFilter> request)
        {
            var source = ConstructFilter(request.Filter);

            var response = await _paginationHelper.PaginateAsync(source, request.PageNumber, request.Limit);
            var mappedResponse = _mapper.Map(response);

            return mappedResponse;
        }

        protected virtual void PrepareForCreation(TDbModel item)
        {
            item.Id = Guid.NewGuid();
            item.IsActive = true;
        }

        protected virtual void SaveImportantInfo(TDbModel beforeSave, TDataModel forSave)
        {
            forSave.Id = beforeSave.Id;
            forSave.IsActive = beforeSave.IsActive;
        }

        private IQueryable<TDbModel> ConstructFilter(TFilter filter)
        {
            var items = _context.Set<TDbModel>().AsQueryable();

            filter ??= new TFilter();

            if (!filter.IsTracking.HasValue || !filter.IsTracking.Value)
            {
                items = items.AsNoTracking();
            }

            if (!filter.OnlyActive.HasValue || filter.OnlyActive.Value)
            {
                items = items.Where(i => i.IsActive);
            }

            if (filter.Id.HasValue)
            {
                items = items.Where(i => i.Id.Equals(filter.Id.Value));
            }

            if (filter.Ids is not null && filter.Ids.Count != 0)
            {
                items = items.Where(i => filter.Ids.Contains(i.Id));
            }

            items = AddFilterConditions(items, filter);

            return items;
        } 

        protected abstract IQueryable<TDbModel> AddFilterConditions(IQueryable<TDbModel> items, TFilter filter);
    }
}
