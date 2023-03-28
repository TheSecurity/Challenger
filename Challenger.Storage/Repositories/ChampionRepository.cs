using Challenger.Core.Entities;
using Challenger.Core.Storage;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Challenger.Core.Repositories;

public class ChampionRepository : IChampionRepository
{
    private readonly IMongoCollection<Champion> _champions;

    public ChampionRepository(IDbConnection db)
    {
        _champions = db.ChampionCollection;
    }

    public async Task<IEnumerable<Champion>> GetChampionsAsync()
        => await _champions.Find(Builders<Champion>.Filter.Empty)
            .ToListAsync();

    public async Task CreateChampionAsync(string name, string imageUrl, IEnumerable<ObjectId>? challengeIds = null)
        => await _champions.InsertOneAsync(new Champion
        {
            Name = name,
            ImageUrl = imageUrl,
            ChallengeIds = challengeIds
        });
}
