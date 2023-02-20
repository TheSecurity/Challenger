using Newtonsoft.Json;

namespace Challenger.Blazor.Models;

public record ChampionModel
(
    string Id,
    ChampionImageModel Image
);

public record ChampionImageModel
(
    [JsonProperty(PropertyName = "full")]
    string Name
);
