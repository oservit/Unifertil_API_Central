using Domain.Features.Sync;
using Infrastructure.Services.Audit;
using Infrastructure.Http;
using Service.Common;
using Infrastructure.Repositories.Sync;

namespace Service.Features.Sync
{
    public class SyncScheduledEventService : ServiceBase<SyncScheduledEvent>, ISyncScheduledEventService
    {
        private readonly ISyncScheduledEventRepository _scheduledEventRepository;

        public SyncScheduledEventService(ISyncScheduledEventRepository scheduledEventRepository, IHttpUserAccessor httpUser, IAuditService auditService)
            : base(scheduledEventRepository, httpUser, auditService)
        {
            _scheduledEventRepository = scheduledEventRepository ?? throw new ArgumentNullException(nameof(scheduledEventRepository));
        }
    }
}
