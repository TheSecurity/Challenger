using Challenger.Storage.Repositories;

namespace Challenger.Importer.Services;

public class ChallengeService
{
    private readonly IChallengeRepository _challengeRepository;

    public ChallengeService(IChallengeRepository challengeRepository)
    {
        _challengeRepository = challengeRepository;
    }

    public async Task SynchronizeChallangesAsync()
    {
        // Load data from files
        // Store them to DB
    }
}
