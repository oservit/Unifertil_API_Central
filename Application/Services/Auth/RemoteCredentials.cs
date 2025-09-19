namespace Application.Services.Auth
{
    /// <summary>
    /// Atributos de autenticação (Credenciais).
    /// </summary>
    public class RemoteCredentials
    {
        /// <summary>
        /// Usuário para autenticação na API remota.
        /// </summary>
        public string User { get; set; } = null!;

        /// <summary>
        /// Senha Criptografada.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Url de Autenticação.
        /// </summary>
        public string AuthUrl { get; set; }

        public RemoteCredentials(string user, string password, string authUrl)
        {
            User = user;
            Password = password;
            AuthUrl = authUrl;
        }
    }
}
