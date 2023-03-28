using Challenger.Core.Entities;
using MongoDB.Driver;

namespace Challenger.Core.Storage;

public interface IDbConnection
{
    MongoClient Client { get; }
    string DbName { get; }
    IMongoCollection<Challenge> ChallengeCollection { get; }
    string ChallengeCollectionName { get; }
    IMongoCollection<Champion> ChampionCollection { get; }
    string ChampionCollectionName { get; }
}