using Challenger.Storage.Dtos;
using Challenger.Storage.Entities;
using MongoDB.Driver;

namespace Challenger.Storage.Repositories;

public class ChampionRepository : IChampionRepository
{
    private readonly IMongoCollection<Champion> _champions;

    public ChampionRepository(IDbConnection db)
    {
        _champions = db.ChampionCollection;
    }

    public async Task<IEnumerable<Champion>> GetChampionsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateChampionAsync(ChampionDto champion)
    {
        throw new NotImplementedException();
    }
}
