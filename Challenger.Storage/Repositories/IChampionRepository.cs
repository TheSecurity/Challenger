using Challenger.Storage.Entities;
using MongoDB.Bson;

namespace Challenger.Storage.Repositories;

public interface IChampionRepository
{
    Task CreateChampionAsync(string name, string imageUrl, IEnumerable<ObjectId>? challengeIds = null);
    Task<IEnumerable<Champion>> GetChampionsAsync();
}