using Application.Common;
using Application.Services.Auth;
using Application.Services.Core;
using Infrastructure.Http;
using Libs.Common;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Sync.Core
{
    public abstract class SyncRemoteServiceBase<TModel> : AuthenticatedAppService, ISyncRemoteServiceBase<TModel>
        where TModel : class, IViewModelBase
    {
        private readonly string _baseUrl;

        protected SyncRemoteServiceBase(
            IApiClient apiClient,
            ITokenService tokenService,
            IConfiguration config,
            string route)
            : base(apiClient, tokenService)
        {
            //_baseUrl = $"{config["Remote:Url"].TrimEnd('/')}/{route}/Sync"; // rever deve fazer um switch com base em um parametro de entrada

            // pega o primeiro remote do array (esse codigo é de exemplo temporário)
            var firstRemote = config.GetSection("Remotes")
                                    .GetChildren()
                                    .FirstOrDefault();

            if (firstRemote == null)
                throw new InvalidOperationException("Nenhuma remote configurada");

            var remoteUrl = firstRemote["Url"]?.TrimEnd('/');
            if (string.IsNullOrEmpty(remoteUrl))
                throw new InvalidOperationException("Remote não possui URL configurada.");

            _baseUrl = $"{remoteUrl}/{route}/Sync";

        }

        public virtual async Task<DataResult> SyncRemote(TModel model)
        {
            return await PostAsync<DataResult>($"{_baseUrl}/Receive", model);
        }
    }
}
