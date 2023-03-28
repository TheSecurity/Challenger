using Challenger.Core.Services;

namespace Challenger.Importer.Services;

public class SynchronizationService
{
    private readonly IChampionService _championService;
    private readonly IChallengeService _challengeService;

    public SynchronizationService(IChampionService championService, IChallengeService challengeService)
    {
        _championService = championService;
        _challengeService = challengeService;
    }

    public async Task Run()
    {
        await _challengeService.CreateChallengeAsync(123, "Test", "url");
    }
}
