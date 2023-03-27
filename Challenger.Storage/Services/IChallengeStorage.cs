using Challenger.Storage.Dtos;

namespace Challenger.Storage.Services;

public interface IChallengeStorage
{
    Task<IEnumerable<ChallengeDto>> GetChallengesAsync();
    Task CreateChallengeAsync(int id, int externalId, string name, string imageUrl);
    Task AddChampionToChallengeAsync(int championId, int challengeId);
}