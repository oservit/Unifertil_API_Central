using Domain.Features.Clients;
using Infrastructure.Repositories.Clients;
using Infrastructure.Services.Audit;
using Infrastructure.Http;
using Service.Common;

namespace Service.Features.Clients
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IHttpUserAccessor _httpUser;
        private readonly IAuditService _auditService;

        public ClientService(IClientRepository clientRepository, IHttpUserAccessor httpUser, IAuditService auditService)
            : base(clientRepository, httpUser, auditService)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _httpUser = httpUser ?? throw new ArgumentNullException(nameof(httpUser));
            _auditService = auditService ?? throw new ArgumentNullException(nameof(auditService));
        }
    }
}
