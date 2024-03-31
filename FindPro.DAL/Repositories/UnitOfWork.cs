using FindPro.DAL.Infrastructure;
using FindPro.DAL.Repositories.Interfaces;

namespace FindPro.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FindProContext _context;

        public UnitOfWork(FindProContext gradingContext)
        {
            _context = gradingContext;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
