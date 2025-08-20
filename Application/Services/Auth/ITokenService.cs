namespace Application.Services.Auth
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(string remoteName = null);
    }
}
