using Microsoft.Extensions.Hosting;

namespace Challenger.Importer.Services;

public class InitialService : IHostedService
{
    private readonly SynchronizationService _synchronizationService;

    public InitialService(SynchronizationService synchronizationService)
    {
        _synchronizationService = synchronizationService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _synchronizationService.Run();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
