using Challenger.Core.Entities;
using MongoDB.Bson;

namespace Challenger.Core.Repositories;

public interface IChampionRepository
{
    Task CreateChampionAsync(Champion champion);
    Task<Champion> GetChampionAsync(ObjectId championId);
    Task<IEnumerable<Champion>> GetChampionsAsync();
    Task UpdateChampionsAsync(ObjectId id, Champion champion);
}