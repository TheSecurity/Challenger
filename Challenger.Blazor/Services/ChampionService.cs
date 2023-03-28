using Challenger.Blazor.Models;
using Challenger.Storage.Entities;
using Challenger.Storage.Repositories;

namespace Challenger.Blazor.Services;

public class ChampionService
{
    private readonly IChampionRepository _championRepository;

    public ChampionService(IChampionRepository championRepository)
    {
        _championRepository = championRepository;
    }

    public async Task<IEnumerable<SelectionModel<Champion>>> GetChampionsAsync()
    {
        var champions = await _championRepository.GetChampionsAsync();

        List<SelectionModel<Champion>> result = new();

        foreach(var c in champions)
            result.Add(new SelectionModel<Champion>()
            { 
                Model = c,
                Type = SelectionType.NotSelected
            });

        return result;
    }
}
