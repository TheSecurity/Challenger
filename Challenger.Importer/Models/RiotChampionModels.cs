using Newtonsoft.Json;

namespace Challenger.Importer.Models;

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
