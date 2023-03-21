using Challenger.Storage.Dtos;

namespace Challenger.Storage.Services;

public interface IChampionStorage
{
    Task<IEnumerable<ChampionDto>> GetChampionsAsync();
    Task CreateChampionAsync(int id, string name, string imageUrl);
}