using Challenger.Storage.Entities;
using MongoDB.Bson;

namespace Challenger.Storage.Repositories;

public interface IChallengeRepository
{
    Task CreateChallengesAsync(int externalId, string name, string imageUrl, IEnumerable<ObjectId>? championIds = null);
    Task<IEnumerable<Challenge>> GetChallengesAsync();
}