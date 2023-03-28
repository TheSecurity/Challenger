using MongoDB.Bson;

namespace Challenger.Storage.Entities;

public class Challenge
{
    public ObjectId Id { get; set; }
    public int ExternalId { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public IEnumerable<ObjectId>? ChampionIds { get; set; }
}