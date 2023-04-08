using Challenger.Core.Entities;
using MongoDB.Bson;

namespace Challenger.Core.Services;

public interface IChallengeService
{
    Task<IEnumerable<Challenge>> GetChallengesAsync();
    Task CreateChallengeAsync(Challenge challenge);
    Task<Challenge> GetChallengeAsync(ObjectId challengeObjectId);
    Task UpdateChallengeAsync(ObjectId id, Challenge challenge);
}
