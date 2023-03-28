﻿using Challenger.Storage.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Challenger.Storage;

public class DbConnection : IDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;
    private const string _connectionId = "MongoDb";

    public string DbName { get; private set; }
    public string ChallengeCollectionName { get; private set; } = "challenges";
    public string ChampionCollectionName { get; private set; } = "champions";

    public MongoClient Client { get; private set; }
    public IMongoCollection<Challenge> ChallengeCollection { get; private set; }
    public IMongoCollection<Champion> ChampionCollection { get; private set; }

    public DbConnection(IConfiguration config)
    {
        _config = config;
        var connectionString = string.Format(_config.GetConnectionString(_connectionId)!, _config["MongoUsername"], _config["MongoPassword"]);
        Client = new MongoClient(connectionString);
        
        DbName = _config["DbName"]!;

        _db = Client.GetDatabase(DbName);

        ChallengeCollection = _db.GetCollection<Challenge>(ChallengeCollectionName);
        ChampionCollection = _db.GetCollection<Champion>(ChampionCollectionName);
    }
}
