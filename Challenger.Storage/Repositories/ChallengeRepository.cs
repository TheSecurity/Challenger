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

    public async Task CreateChallengeAsync(Challenge challenge)
        => await _challenges.InsertOneAsync(challenge);

    public async Task<Challenge> GetChallengeAsync(ObjectId challengeObjectId)
        => await _challenges.Find(Builders<Challenge>.Filter.Eq(x => x.Id, challengeObjectId))
            .FirstOrDefaultAsync();

    public async Task UpdateChallengeAsync(ObjectId id, Challenge challenge)
        => await _challenges.ReplaceOneAsync(Builders<Challenge>.Filter.Eq(x => x.Id, id), challenge, new ReplaceOptions { IsUpsert = true });
}
