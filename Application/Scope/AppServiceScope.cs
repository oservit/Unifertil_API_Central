using Application.Features.Authentication;
using Application.Features.Clients;
using Application.Features.Products;
using Application.Features.Sync.Products;
using Application.Services.Auth;
using Application.Services.Sync;
using Microsoft.Extensions.DependencyInjection;
using Service.Common;
using Service.Features.Sync;

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
            services.AddScoped<ISyncScheduledAppService, SyncScheduledAppService>();
        }
    }
}
