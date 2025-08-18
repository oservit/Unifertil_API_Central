using Microsoft.Extensions.DependencyInjection;
using Service.Features.Authentication;
using Service.Features.Products;
using Service.Features.Clients;

namespace Service.Scope
{
    public class ServiceScope
    {
        /// <summary>
        /// Registra os Serviços.
        /// </summary>
        /// <param name="services"></param>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
