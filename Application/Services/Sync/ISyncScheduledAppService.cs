namespace Application.Services.Sync
{
    public interface ISyncScheduledAppService
    {
        /// <summary>
        /// Processa todos os eventos agendados pendentes.
        /// </summary>
        Task ProcessScheduledAsync();
    }
}
