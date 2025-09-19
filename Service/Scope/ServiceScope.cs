using Microsoft.Extensions.DependencyInjection;
using Service.Features.Authentication;
using Service.Features.Clients;
using Service.Features.Products;
using Service.Features.Sync;

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

            services.AddScoped<ISyncLogService, SyncLogService>();
            services.AddScoped<ISyncHashService, SyncHashService>();
            services.AddScoped<ISyncBatchService, SyncBatchService>();
            services.AddScoped<ISyncRouteService, SyncRouteService>();
            services.AddScoped<ISyncNodeService, SyncNodeService>();
            services.AddScoped<ISyncViewRouteUserService, SyncViewRouteUserService>();
            services.AddScoped<ISyncScheduledEventService, SyncScheduledEventService>();
        }
    }
}
