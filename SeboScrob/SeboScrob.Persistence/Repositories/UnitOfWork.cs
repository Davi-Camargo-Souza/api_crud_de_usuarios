using SeboScrob.Domain.Interfaces;
using SeboScrob.Persistence.Context;

namespace SeboScrob.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext appDbContext) 
        { 
            _context = appDbContext;
        }
        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();
        }
    }
}
