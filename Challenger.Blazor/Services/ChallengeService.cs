using Challenger.Blazor.Models;
using Challenger.Storage.Entities;
using Challenger.Storage.Repositories;

namespace Challenger.Blazor.Services;

public class ChallengeService
{
    private readonly IChallengeRepository _challengeStorage;

    public ChallengeService(IChallengeRepository challengeStorage)
    {
        _challengeStorage = challengeStorage;
    }

    public async Task<IEnumerable<SelectionModel<Challenge>>> GetChallengesAsync()
    {
        var challeges = (await _challengeStorage.GetChallengesAsync()).ToList();
        List<SelectionModel<Challenge>> result = new();

        foreach (var c in challeges)
            result.Add(new SelectionModel<Challenge>()
            {
                Model = c,
                Type = SelectionType.NotSelected
            });

        return result;
    }
}
