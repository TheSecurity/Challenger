using Challenger.Core.Entities;
using Challenger.Core.Repositories;
using MongoDB.Bson;

namespace Challenger.Core.Services;

public class ChampionService : IChampionService
{
    private readonly IChampionRepository _championRepository;

    public ChampionService(IChampionRepository championRepository)
    {
        _championRepository = championRepository;
    }

    public async Task CreateChampionsAsync(string name, string imageUrl, IEnumerable<ObjectId>? challengeIds = null)
        => await _championRepository.CreateChampionAsync(name, imageUrl, challengeIds);

    public async Task<IEnumerable<Champion>> GetChampionsAsync()
        => await _championRepository.GetChampionsAsync();
}
