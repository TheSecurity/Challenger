using Challenger.Storage.Dtos;
using Challenger.Storage.Entities;

namespace Challenger.Storage.Services;

public class ChallengeMemoryStorage : IChallengeStorage
{
    private static List<Challenge> _challengeDatabase = new List<Challenge>();
    
    public Task AddChampionToChallengeAsync(int championId, int challengeId)
    {
        Challenge? challenge = null;

        foreach(var c in _challengeDatabase)
            if(challengeId == c.Id)
                challenge = c;

        if(challenge is null)
            return Task.CompletedTask;

        if(challenge.ChampionIds is null)
            challenge.ChampionIds = new List<int>();

        challenge.ChampionIds.Add(championId);

        return Task.CompletedTask;
    }

    public Task CreateChallengeAsync(int id, int externalId, string name, string imageUrl)
    {
        _challengeDatabase.Add(new Challenge()
        {
            Id = id,
            ExternalId = externalId,
            Name = name,
            ImageUrl = imageUrl
        });

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<ChallengeDto>> GetChallengesAsync()
    {
        List<ChallengeDto> challenges = new List<ChallengeDto>();

        foreach (Challenge c in _challengeDatabase)
        {
            ChallengeDto challenge = new ChallengeDto()
            {
                Id = c.Id,
                ExternalId = c.ExternalId,
                Name = c.Name,
                ImageUrl = c.ImageUrl,
                ChampionIds = c.ChampionIds
            };  

            challenges.Add(challenge);
        }

        return await Task.FromResult(challenges);
    }
}
