using Challenger.Blazor.Models;
using Challenger.Storage.Services;

namespace Challenger.Blazor.Services;

public class ChampionService
{
    private readonly IChampionStorage _championStorage;

    public ChampionService(IChampionStorage championStorage)
    {
        _championStorage = championStorage;
    }

    public async Task<IEnumerable<ChampionModel>> GetChampionsAsync()
    {
        var champions = await _championStorage.GetChampionsAsync();

        List<ChampionModel> result = new List<ChampionModel>();

        foreach(var c in champions)
            result.Add(new ChampionModel()
            { 
                Id = c.Id, 
                Name = c.Name, 
                ImageUrl = c.ImageUrl, 
                Selection = SelectionType.NotSelected
            });

        return result;
    }
}
