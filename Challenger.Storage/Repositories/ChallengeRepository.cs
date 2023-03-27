using Challenger.Storage.Dtos;
using Challenger.Storage.Entities;
using MongoDB.Driver;

namespace Challenger.Storage.Repositories;

public class ChallengeRepository : IChallengeRepository
{
    private readonly IMongoCollection<Challenge> _challenges;

    public ChallengeRepository(IDbConnection db)
    {
        _challenges = db.ChallengeCollection;
    }

    public async Task<IEnumerable<Challenge>> GetChallengesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateChallengesAsync(ChallengeDto challenge)
    {
        throw new NotImplementedException();
    }

}
