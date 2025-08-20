using Application.Services.Core;
using Infrastructure.Http;
using Libs;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Auth
{
    public class TokenService : ITokenService
    {
        private readonly IApiClient _apiClient;
        private readonly IConfiguration _config;
        private string? _cachedToken;
        private DateTime _expiresAt;

        public TokenService(IApiClient apiClient, IConfiguration config)
        {
            _apiClient = apiClient;
            _config = config;
        }

        public async Task<string> GetTokenAsync(string remoteName = null)
        {
            // Retorna token cacheado se ainda válido
            if (!string.IsNullOrEmpty(_cachedToken) && _expiresAt > DateTime.UtcNow.AddMinutes(1))
                return _cachedToken;

            // Seleciona a remote
            IConfigurationSection remoteSection;
            if (string.IsNullOrEmpty(remoteName))
            {
                // pega a primeira remote por enquanto
                remoteSection = _config.GetSection("Remotes").GetChildren().FirstOrDefault();
                if (remoteSection == null)
                    throw new InvalidOperationException("Nenhuma remote configurada");
            }
            else
            {
                // futuramente: busca remote por nome
                remoteSection = _config.GetSection("Remotes")
                                       .GetChildren()
                                       .FirstOrDefault(r => r["Name"] == remoteName);

                if (remoteSection == null)
                    throw new InvalidOperationException($"Remote '{remoteName}' não encontrada");
            }

            // Cria o objeto de usuário
            var user = new
            {
                username = remoteSection["User"],
                password = Crypto.Decrypt(remoteSection["Password"])
            };

            // URL da remote
            var remoteUrl = remoteSection["Url"]?.TrimEnd('/');
            if (string.IsNullOrEmpty(remoteUrl))
                throw new InvalidOperationException("Remote não possui URL configurada");

            // POST para login
            var response = await _apiClient.PostAsync<ApiResponse<string>>(
                $"{remoteUrl}/Auth/GetToken",
                user
            );

            if (response?.Success != true || string.IsNullOrEmpty(response.Data))
                throw new Exception("Falha ao autenticar na API Remote");

            // Cache do token com Bearer
            _cachedToken = response.Data;
            _expiresAt = DateTime.UtcNow.AddMinutes(30);

            return _cachedToken;
        }

    }
}
