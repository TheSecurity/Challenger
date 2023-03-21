using BlazorWebAssemblyDemo.UI.Services;
using Challenger.Storage.Dtos;
using Newtonsoft.Json;

namespace Challenger.Blazor.Services;

public class ChampionService
{
    public static async Task<IEnumerable<ChampionDto>?> GetChampionsAsync()
    {
        using var client = new HttpClient();

        var result = await client.GetAsync("https://ddragon.leagueoflegends.com/cdn/13.3.1/data/en_US/champion.json");

        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await result.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<IEnumerable<ChampionDto>>(content, new ChampionJsonConverter());
    }

    public static async Task SaveChampionsAsync(IEnumerable<ChampionDto> champions)
    {
        string filePath = "C:\\Users\\Tomáš\\Desktop\\champ_data.json";

        string content = JsonConvert.SerializeObject(champions, Formatting.Indented);

        await File.WriteAllTextAsync(filePath, content);
    }
}
