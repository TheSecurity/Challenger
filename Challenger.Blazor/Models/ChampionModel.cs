namespace Challenger.Blazor.Models;
public class ChampionModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;

    public SelectionType Selection { get; set; }
}
