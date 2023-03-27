using Challenger.Storage.Dtos;
using Challenger.Storage.Entities;

namespace Challenger.Storage.Services;

public class ChampionMemoryStorage : IChampionStorage
{

    private static List<Champion> _championDatabase = new List<Champion>();

    public Task CreateChampionAsync(int id, string name, string imageUrl)
    {
        _championDatabase.Add(new Champion
        {
            Id = id,
            Name = name,
            ImageUrl = imageUrl
        });

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<ChampionDto>> GetChampionsAsync()
    {
        List<ChampionDto> champs = new List<ChampionDto>();

        foreach(var champion in _championDatabase)
        {
            ChampionDto champ = new ChampionDto()
            {
                Id = champion.Id,
                Name = champion.Name,
                ImageUrl = champion.ImageUrl

            };

            champs.Add(champ);
        }

        return await Task.FromResult(champs);
    }
}
