using Challenger.Core.Entities;
using MongoDB.Bson;

namespace Challenger.Core.Repositories;

public interface IChallengeRepository
{
    Task CreateChallengeAsync(int externalId, string name, string imageUrl, IEnumerable<ObjectId>? championIds = null);
    Task<IEnumerable<Challenge>> GetChallengesAsync();
}