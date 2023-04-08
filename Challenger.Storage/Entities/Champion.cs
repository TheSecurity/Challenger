using MongoDB.Bson;

namespace Challenger.Core.Entities;

public class Champion
{
    public ObjectId Id { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public ICollection<ObjectId>? ChallengeIds { get; set; }
}