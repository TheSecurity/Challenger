using Challenger.Storage.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Challenger.Storage.Repositories;

public class ChampionRepository : IChampionRepository
{
    private readonly IMongoCollection<Champion> _champions;

    public ChampionRepository(IDbConnection db)
    {
        _champions = db.ChampionCollection;
    }

    public Task<IEnumerable<Champion>> GetChampionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateChampionAsync(string name, string imageUrl, IEnumerable<ObjectId>? challengeIds = null)
    {
        throw new NotImplementedException();
    }
}
