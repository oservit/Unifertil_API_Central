using Application.Features.Authentication;
using Application.Services.Auth;
using Application.Features.Clients;
using Application.Features.Products;
using Application.Features.Sync.Products;
using Microsoft.Extensions.DependencyInjection;
using Service.Common;

namespace Application.Scope
{
    public class AppServiceScope
    {
        internal static void Register(IServiceCollection services)
        {

            services.AddScoped<IServiceFactory, ServiceFactory>();

            services.AddScoped<IClientAppService, ClientAppService>();

            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();

            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IProductSyncAppService, ProductSyncAppService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
