using Challenger.Storage.Dtos;
using Challenger.Blazor.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlazorWebAssemblyDemo.UI.Services;

public class ChampionJsonConverter : JsonConverter<IEnumerable<ChampionDto>>
{
    private const string BaseContentPath = "https://ddragon.leagueoflegends.com/cdn/13.3.1";
    private const string ChampionPath = BaseContentPath + "/img/champion/";

    public override IEnumerable<ChampionDto>? ReadJson(JsonReader reader, Type objectType, IEnumerable<ChampionDto>? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jObject = JObject.Load(reader);

        var values = jObject.GetValue("data")?.Values().ToList();
        var parsedModels = values?.Select(x => x.ToObject<RiotChampionModel>()!);

        int i = 1;

        return parsedModels?.Select(x => new ChampionDto
        {
            Id = i++,
            Name = x.Name,
            ImageUrl = ChampionPath + x.Image.Name
        });
    }

    public override void WriteJson(JsonWriter writer, IEnumerable<ChampionDto>? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
