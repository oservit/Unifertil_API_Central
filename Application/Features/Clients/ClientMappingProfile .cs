using AutoMapper;
using Domain.Features.Clients;

namespace Application.Features.Clients.Mapping
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientViewModel, Client>();
            CreateMap<CreateClientModel, Client>();
            CreateMap<UpdateClientModel, Client>();
            CreateMap<Client, ClientViewModel>();
        }
    }
}
