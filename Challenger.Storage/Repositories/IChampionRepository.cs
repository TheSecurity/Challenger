using Challenger.Storage.Dtos;
using Challenger.Storage.Entities;

namespace Challenger.Storage.Repositories
{
    public interface IChampionRepository
    {
        Task CreateChampionAsync(ChampionDto champion);
        Task<IEnumerable<Champion>> GetChampionsAsync();
    }
}