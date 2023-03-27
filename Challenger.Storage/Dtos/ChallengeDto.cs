namespace Challenger.Storage.Dtos;

public class ChallengeDto
{
    public int Id { get; set; }
    public int ExternalId { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public IEnumerable<int>? ChampionIds { get; set; }
}
