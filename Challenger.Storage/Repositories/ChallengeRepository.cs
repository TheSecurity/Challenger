using Challenger.Storage.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Challenger.Storage.Repositories;

public class ChallengeRepository : IChallengeRepository
{
    private readonly IMongoCollection<Challenge> _challenges;

    public ChallengeRepository(IDbConnection db)
    {
        _challenges = db.ChallengeCollection;
    }

    public Task<IEnumerable<Challenge>> GetChallengesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateChallengesAsync(int externalId, string name, string imageUrl, IEnumerable<ObjectId>? championIds)
    {
        await _challenges.InsertOneAsync(new Challenge
        {
            ExternalId = externalId,
            Name = name,
            ImageUrl = imageUrl,
            ChampionIds = championIds
        });
    }
}
