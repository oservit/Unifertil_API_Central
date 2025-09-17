using Infrastructure.Data;
using Infrastructure.Repositories.Common;
using Domain.Features.Sync.Integrator;

namespace Infrastructure.Repositories.Sync
{
    public class SyncProductViewRepository : SelectRepository<SyncProductView>, ISyncProductViewRepository
    {
        public SyncProductViewRepository(AppDataContext context) : base(context)
        {
        }
    }
}
