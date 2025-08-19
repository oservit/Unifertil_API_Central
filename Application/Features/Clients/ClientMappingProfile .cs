using Application.Features.Products;
using AutoMapper;
using Domain.Features.Clients;
using Domain.Features.Products;

namespace Application.Features.Clients.Mapping
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<CreateClientModel, Client>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ClientViewModel, Client>();
            CreateMap<UpdateClientModel, Client>();
            CreateMap<Client, ClientViewModel>();
        }
    }
}
