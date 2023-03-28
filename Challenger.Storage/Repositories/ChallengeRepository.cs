using Challenger.Core.Entities;
using Challenger.Core.Storage;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Challenger.Core.Repositories;

public class ChallengeRepository : IChallengeRepository
{
    private readonly IMongoCollection<Challenge> _challenges;

    public ChallengeRepository(IDbConnection db)
    {
        _challenges = db.ChallengeCollection;
    }

    public async Task<IEnumerable<Challenge>> GetChallengesAsync()
        => await _challenges.Find(Builders<Challenge>.Filter.Empty)
            .ToListAsync();

    public async Task CreateChallengeAsync(int externalId, string name, string imageUrl, IEnumerable<ObjectId>? championIds)
        => await _challenges.InsertOneAsync(new Challenge
        {
            ExternalId = externalId,
            Name = name,
            ImageUrl = imageUrl,
            ChampionIds = championIds
        });
}
