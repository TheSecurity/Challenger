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

    public async Task CreateChampionAsync(Champion champion)
        => await _champions.InsertOneAsync(champion);

    public async Task<Champion> GetChampionAsync(ObjectId championId)
        => await _champions.Find(Builders<Champion>.Filter.Eq(x => x.Id, championId))
            .FirstOrDefaultAsync();

    public async Task UpdateChampionsAsync(ObjectId id, Champion champion)
        => await _champions.ReplaceOneAsync(Builders<Champion>.Filter.Eq(x => x.Id, id), champion, new ReplaceOptions { IsUpsert = true });
}
