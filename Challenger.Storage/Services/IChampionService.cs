using Challenger.Core.Entities;
using MongoDB.Bson;

namespace Challenger.Core.Services;

public interface IChampionService
{
    Task<IEnumerable<Champion>> GetChampionsAsync();
    Task CreateChampionsAsync(string name, string imageUrl, IEnumerable<ObjectId>? challengeIds = null);
}
