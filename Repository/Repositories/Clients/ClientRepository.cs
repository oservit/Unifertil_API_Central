using Infrastructure.Data;
using Domain.Features.Clients;
using Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories.Clients
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(ExternalDataContext context) : base(context)
        {
        }
    }
}
