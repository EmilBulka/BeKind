
using BeKind.Infrastructure;

namespace StockNewsTracker.Infrastructure.Repositories
{
    public class BaseRepository : IAsyncDisposable
    {
        protected StockNewsMasterDbContext MasterDbContext { get; }
        public BaseRepository(StockNewsMasterDbContext dbContext)
        {
            MasterDbContext = dbContext;
        }

        public async ValueTask DisposeAsync()
        {
            await MasterDbContext.DisposeAsync().ConfigureAwait(false);
            GC.SuppressFinalize(this);
        }
    }
}