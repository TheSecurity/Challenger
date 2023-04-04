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

    public async Task CreateChampionsAsync(Champion champion)
        => await _championRepository.CreateChampionAsync(champion);

    public async Task<Champion> GetChampionAsync(ObjectId championId)
        => await _championRepository.GetChampionAsync(championId);

    public async Task<IEnumerable<Champion>> GetChampionsAsync()
        => await _championRepository.GetChampionsAsync();

    public async Task UpdateChampionsAsync(ObjectId id, Champion champion)
        => await _championRepository.UpdateChampionsAsync(id, champion);
}
