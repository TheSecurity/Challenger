using Challenger.Core.Entities;
using MongoDB.Bson;

namespace Challenger.Core.Repositories;

public interface IChallengeRepository
{
    Task CreateChallengeAsync(Challenge challenge);
    Task<Challenge> GetChallengeAsync(ObjectId challengeObjectId);
    Task<IEnumerable<Challenge>> GetChallengesAsync();
    Task UpdateChallengeAsync(ObjectId id, Challenge challenge);
}