using Challenger.Core.Entities;
using Challenger.Core.Services;
using Challenger.Importer.Dtos;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Challenger.Importer.Services;

public class SynchronizationService
{
    private readonly IChampionService _championService;
    private readonly IChallengeService _challengeService;
    private const string ChampionImageBaseUrl = "https://ddragon.leagueoflegends.com/cdn/13.3.1/img/champion/";
    private const string ChallengeImageBaseUrl = "https://ddragon.leagueoflegends.com/cdn/img/challenges-images/";

    public SynchronizationService(IChampionService championService, IChallengeService challengeService)
    {
        _championService = championService;
        _challengeService = challengeService;
    }

    public async Task Run()
    {
        Dictionary<int, ObjectId> championMapping = new Dictionary<int, ObjectId>();
        Dictionary<int, ObjectId> challengeMapping = new Dictionary<int, ObjectId>();

        var champs = (await GetDataAsync<IEnumerable<ChampionDto>>("champions.json"))?.ToDictionary(x => x.Id, x => x);
        var challenges = (await GetDataAsync<IEnumerable<ChallengeDto>>("challenges.json"))?.ToDictionary(x => x.Id, x => x);
        var challengesToChampions = await GetDataAsync<IEnumerable<ChampionChallengeDto>>("challenge_champions.json");

        foreach (var c in challengesToChampions)
        {
            if (!challengeMapping.TryGetValue(c.ChallengeId, out var challengeObjectId))
            {
                if (!challenges.TryGetValue(c.ChallengeId, out var x))
                    throw new Exception("ChallengeId not found");

                Challenge chall = new Challenge()
                {
                    Name = x.Name,
                    ExternalId = x.ExternalId,
                    ImageUrl = ChallengeImageBaseUrl + x.ExternalId + "-GRANDMASTER.png"
                };

                await _challengeService.CreateChallengeAsync(chall);

                challengeMapping.Add(c.ChallengeId, chall.Id);

                challengeObjectId = chall.Id;
            }

            if (!championMapping.TryGetValue(c.ChampionId, out var championObjectId))
            {
                if (!champs.TryGetValue(c.ChampionId, out var x))
                    throw new Exception("ChampionId not found");

                Champion ch = new Champion()
                {
                    Name = x.Name,
                    ImageUrl = ChampionImageBaseUrl + x.Name + ".png"
                };

                await _championService.CreateChampionsAsync(ch);

                championMapping.Add(c.ChampionId, ch.Id);

                championObjectId = ch.Id;
            }

            Champion champ = await _championService.GetChampionAsync(championObjectId);
            champ.ChallengeIds ??= new List<ObjectId>();
            champ.ChallengeIds.Add(challengeObjectId);
            await _championService.UpdateChampionsAsync(champ.Id, champ);

            Challenge chl = await _challengeService.GetChallengeAsync(challengeObjectId);
            chl.ChampionIds ??= new List<ObjectId>();
            chl.ChampionIds.Add(championObjectId);
            await _challengeService.UpdateChallengeAsync(chl.Id, chl);
        }
    }

    private async Task<T?> GetDataAsync<T>(string fileName)
    {
        var path = "C:\\Users\\Tomáš\\Desktop\\Lol_app\\";

        string content = await File.ReadAllTextAsync(path + fileName);

        T? items = JsonConvert.DeserializeObject<T>(content);

        return items;
    }
}
