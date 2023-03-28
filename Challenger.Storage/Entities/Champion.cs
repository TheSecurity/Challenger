using MongoDB.Bson;

namespace Challenger.Storage.Entities;

public class Champion
{
    public ObjectId Id { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public IEnumerable<ObjectId>? Challenges { get; set; }
}