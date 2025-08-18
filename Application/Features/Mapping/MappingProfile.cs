using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Mapping
{
    public static class ApplicationMappingScope
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(Authentication.Mapping.AuthenticationMappingProfile),
                typeof(Clients.Mapping.ClientMappingProfile),
                typeof(Products.Mapping.ProductMappingProfile)
            // Adicione outros profiles aqui
            );
        }
    }
}

