using Challenger.Storage.Dtos;
using Challenger.Storage.Entities;

namespace Challenger.Storage.Repositories
{
    public interface IChallengeRepository
    {
        Task CreateChallengesAsync(ChallengeDto challenge);
        Task<IEnumerable<Challenge>> GetChallengesAsync();
    }
}