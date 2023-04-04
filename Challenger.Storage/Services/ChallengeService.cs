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

    public async Task CreateChallengeAsync(Challenge challenge)
        => await _challengeRepository.CreateChallengeAsync(challenge);

    public async Task<Challenge> GetChallengeAsync(ObjectId challengeObjectId)
        => await _challengeRepository.GetChallengeAsync(challengeObjectId);

    public async Task<IEnumerable<Challenge>> GetChallengesAsync()
        => await _challengeRepository.GetChallengesAsync();

    public async Task UpdateChallengeAsync(ObjectId id, Challenge challenge)
        => await _challengeRepository.UpdateChallengeAsync(id, challenge);
}
