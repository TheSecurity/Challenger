using Challenger.Blazor.Models;
using Challenger.Storage.Dtos;
using Challenger.Storage.Services;

namespace Challenger.Blazor.Services;

public class ChallengeService
{
    private readonly IChallengeStorage _challengeStorage;

    public ChallengeService(IChallengeStorage challengeStorage)
    {
        _challengeStorage = challengeStorage;
    }

    public async Task<IEnumerable<ChallengeModel>> GetChallengesAsync()
    {
        List<ChallengeModel> result = new List<ChallengeModel>();

        List<ChallengeDto> challeges = (await _challengeStorage.GetChallengesAsync()).ToList();

        foreach (var c in challeges)
        {
            var challenge = new ChallengeModel()
            {
                ChampionIds = c.ChampionIds,
                ExternalId = c.ExternalId,
                Id = c.Id,
                ImageUrl = c.ImageUrl,
                Name = c.Name,
                Selection = SelectionType.NotSelected
            };

            result.Add(challenge);
        }

        return result;
    }
}
