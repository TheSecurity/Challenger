using Challenger.Core.Entities;
using MongoDB.Bson;

namespace Challenger.Core.Services;

public interface IChampionService
{
    Task<IEnumerable<Champion>> GetChampionsAsync();
    Task CreateChampionsAsync(Champion champion);
    Task<Champion> GetChampionAsync(ObjectId championId);
    Task UpdateChampionsAsync(ObjectId id, Champion champion);
}
