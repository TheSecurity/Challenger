using Newtonsoft.Json;

namespace Challenger.Blazor.Models;

public record RiotChampionModel
(
    [JsonProperty(PropertyName = "id")]
    string Name,
    RiotChampionImageModel Image
);

public record RiotChampionImageModel
(
    [JsonProperty(PropertyName = "full")]
    string Name
);
