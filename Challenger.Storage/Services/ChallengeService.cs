using Challenger.Core.Entities;
using Challenger.Core.Repositories;
using MongoDB.Bson;

namespace Challenger.Core.Services;

public class ChallengeService : IChallengeService
{
    private readonly IChallengeRepository _challengeRepository;

    public ChallengeService(IChallengeRepository challengeRepository)
    {
        _challengeRepository = challengeRepository;
    }

    public async Task CreateChallengeAsync(int externalId, string name, string imageUrl, IEnumerable<ObjectId>? championIds = null)
        => await _challengeRepository.CreateChallengeAsync(externalId, name, imageUrl, championIds);

    public async Task<IEnumerable<Challenge>> GetChallengesAsync()
        => await _challengeRepository.GetChallengesAsync();
}
