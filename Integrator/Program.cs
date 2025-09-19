using Microsoft.Extensions.DependencyInjection;
using Application.Common;
using Application.Services.Sync;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        await RunScheduledProcessingAsync(serviceProvider);
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Registra HttpClient
        services.AddHttpClient();

        // Registra todos os serviços e scopes do sistema
        Configuration.RegisterServices(services);

        // Aqui você poderia adicionar AppSettings, se houver
        // var appSettings = LoadAppSettings();
        // services.AddSingleton(appSettings);

        return services.BuildServiceProvider();
    }

    private static async Task RunScheduledProcessingAsync(ServiceProvider serviceProvider)
    {
        try
        {
            // Resolve o serviço via interface
            var scheduledService = serviceProvider.GetRequiredService<ISyncScheduledAppService>();

            // Executa processamento
            await scheduledService.ProcessScheduledAsync();

            Console.WriteLine("Processamento concluído!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no processamento: {ex.Message}");
        }
    }
}
