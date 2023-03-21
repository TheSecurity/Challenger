using Challenger.Storage.Dtos;
using Newtonsoft.Json;

namespace Challenger.Blazor.Services;

public class ChallengeService
{
    public static async Task SaveChallengesAsync(IEnumerable<ChallengeDto> challenges)
    {
        string filePath = "C:\\Users\\Tomáš\\Desktop\\challenge_data.json";

        string content = JsonConvert.SerializeObject(challenges, Formatting.Indented);

        await File.WriteAllTextAsync(filePath, content);
    }

    public static async Task SaveChallengeToChampionAsync(IEnumerable<ChampionChallengeDto> championChallenge)
    {
        string filePath = "C:\\Users\\Tomáš\\Desktop\\championChallenge_data.json";

        string content = JsonConvert.SerializeObject(championChallenge, Formatting.Indented);

        await File.WriteAllTextAsync(filePath, content);
    }

    public static async Task<IEnumerable<ChallengeDto>> GetChallengesAsync()
    {
        string filePath = "C:\\Users\\Tomáš\\Desktop\\challenge_data.json";

        string content = await File.ReadAllTextAsync(filePath);

        var challenges = JsonConvert.DeserializeObject<IEnumerable<ChallengeDto>>(content);

        return challenges ?? new List<ChallengeDto>();
    }

    public static async Task<IEnumerable<ChampionChallengeDto>> GetChampionChallengesAsync()
    {
        string filePath = "C:\\Users\\Tomáš\\Desktop\\championChallenge_data.json";

        string content = await File.ReadAllTextAsync(filePath);

        var championChallenges = JsonConvert.DeserializeObject<IEnumerable<ChampionChallengeDto>>(content);

        return championChallenges ?? new List<ChampionChallengeDto>();
    }

}
