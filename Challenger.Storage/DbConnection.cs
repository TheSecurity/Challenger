using Challenger.Storage.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Challenger.Storage;

public class DbConnection : IDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;
    private string _connectionId = "MongoDb";

    public string DbName { get; private set; }
    public string ChallengeCollectionName { get; private set; } = "challenges";
    public string ChampionCollectionName { get; private set; } = "champions";

    public MongoClient Client { get; private set; }
    public IMongoCollection<Challenge> ChallengeCollection { get; private set; }
    public IMongoCollection<Champion> ChampionCollection { get; private set; }

    public DbConnection(IConfiguration config)
    {
        _config = config;
        Client = new MongoClient(_config.GetConnectionString(_connectionId));

        if (_config["DatabaseName"] is not string name)
            throw new ArgumentNullException(nameof(DbName));
        DbName = name;

        _db = Client.GetDatabase(DbName);

        ChallengeCollection = _db.GetCollection<Challenge>(ChallengeCollectionName);
        ChampionCollection = _db.GetCollection<Champion>(ChampionCollectionName);
    }
}
