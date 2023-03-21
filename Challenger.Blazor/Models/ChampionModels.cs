using Newtonsoft.Json;

namespace Challenger.Blazor.Models;

public record ChampionModel
(
    [JsonProperty(PropertyName = "id")]
    string Name,
    ChampionImageModel Image
);

public record ChampionImageModel
(
    [JsonProperty(PropertyName = "full")]
    string Name
);
