using Infrastructure.Data;
using Infrastructure.Repositories.Common;
using Domain.Features.Sync;

namespace Infrastructure.Repositories.Sync
{
    public class SyncScheduledEventRepository : RepositoryBase<SyncScheduledEvent>, ISyncScheduledEventRepository
    {
        public SyncScheduledEventRepository(AppDataContext context) : base(context)
        {
        }
    }
}
