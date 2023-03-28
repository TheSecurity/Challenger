using Challenger.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Challenger.Core.Storage;

public class DbConnection : IDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;

    public string DbName { get; private set; }
    public string ChallengeCollectionName { get; private set; } = "challenges";
    public string ChampionCollectionName { get; private set; } = "champions";

    public MongoClient Client { get; private set; }
    public IMongoCollection<Challenge> ChallengeCollection { get; private set; }
    public IMongoCollection<Champion> ChampionCollection { get; private set; }

    public DbConnection(IConfiguration config)
    {
        _config = config;

        Client = new MongoClient(_config["MongoDbConnectionString"]!);
        DbName = _config["DbName"]!;

        _db = Client.GetDatabase(DbName);

        ChallengeCollection = _db.GetCollection<Challenge>(ChallengeCollectionName);
        ChampionCollection = _db.GetCollection<Champion>(ChampionCollectionName);
    }
}
