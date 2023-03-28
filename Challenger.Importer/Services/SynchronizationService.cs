using Microsoft.Extensions.Hosting;

namespace Challenger.Importer.Services;

public class SynchronizationService : IHostedService
{
    private readonly ChallengeService _challengeService;
    private readonly ChampionService _championService;

    public SynchronizationService(ChallengeService challengeService, ChampionService championService)
    {
        _challengeService = challengeService;
        _championService = championService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _challengeService.SynchronizeChallangesAsync();
        await _championService.SynchronizeChampionsAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
