using Challenger.Storage.Dtos;
using System.Collections.Generic;

namespace Challenger.Storage.Entities;

public class Challenge
{
    public int Id { get; set; }
    public int ExternalId { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public ICollection<int>? ChampionIds { get; set; }
}