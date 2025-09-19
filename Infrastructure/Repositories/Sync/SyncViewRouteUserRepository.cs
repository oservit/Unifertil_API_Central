using Domain.Features.Sync.Views;
using Infrastructure.Data;
using Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories.Sync
{
    public class SyncViewRouteUserRepository : SelectRepository<SyncRouteUserView>, ISyncViewRouteUserRepository
    {
        public SyncViewRouteUserRepository(AppDataContext context) : base(context)
        {
        }
    }
}
