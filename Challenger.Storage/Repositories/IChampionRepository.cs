using Challenger.Core.Entities;
using MongoDB.Bson;

namespace Challenger.Core.Repositories;

public interface IChampionRepository
{
    Task CreateChampionAsync(string name, string imageUrl, IEnumerable<ObjectId>? challengeIds = null);
    Task<IEnumerable<Champion>> GetChampionsAsync();
}