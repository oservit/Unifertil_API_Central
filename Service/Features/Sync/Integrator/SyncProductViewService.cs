using Infrastructure.Http;
using Service.Common;
using Infrastructure.Repositories.Sync;
using Domain.Features.Sync.Integrator;

namespace Service.Features.Sync
{
    public class SyncProductViewService : SelectService<SyncProductView>, ISyncProductViewService
    {
        private readonly ISyncProductViewRepository _vwRepository;

        public SyncProductViewService(ISyncProductViewRepository vwRepository, IHttpUserAccessor httpUser)
            : base(vwRepository, httpUser)
        {
            _vwRepository = vwRepository ?? throw new ArgumentNullException(nameof(vwRepository));
        }
    }
}
