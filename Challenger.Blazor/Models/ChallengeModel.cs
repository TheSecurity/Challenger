namespace Challenger.Blazor.Models;
public class ChallengeModel
{
    public int Id { get; set; }
    public int ExternalId { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public IEnumerable<int>? ChampionIds { get; set; }

    public SelectionType Selection { get; set; }
}
