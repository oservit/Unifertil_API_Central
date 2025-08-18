using Application.Features.Base;
using AutoMapper;
using Domain.Features.Clients;
using Domain.Settings;
using Microsoft.Extensions.Options;
using Service.Features.Clients;

namespace Application.Features.Clients
{
    public class ClientAppService : AppServiceBase<Client, ClientViewModel>, IClientAppService
    {
        public ClientAppService(IClientService service, IMapper mapper, IOptions<AppSettings> settings) : base(service, mapper, settings)
        {
        }
    }
}
