using Challenger.Core.Entities;
using MongoDB.Bson;

namespace Challenger.Core.Services;

public interface IChallengeService
{
    Task<IEnumerable<Challenge>> GetChallengesAsync();
    Task CreateChallengeAsync(int externalId, string name, string imageUrl, IEnumerable<ObjectId>? championIds = null);
}
