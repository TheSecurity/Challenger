using MongoDB.Bson;

namespace Challenger.Core.Entities;

public class Challenge
{
    public ObjectId Id { get; set; }
    public int ExternalId { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public ICollection<ObjectId>? ChampionIds { get; set; }
}