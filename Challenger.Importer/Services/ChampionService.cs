using Challenger.Storage.Repositories;

namespace Challenger.Importer.Services;

public class ChampionService
{
    private readonly IChampionRepository _championRepository;

    public ChampionService(IChampionRepository championRepository)
    {
        _championRepository = championRepository;
    }

    public Task SynchronizeChampionsAsync()
    {
        // Load data from files
        // Store them to DB
        throw new NotImplementedException();
    }
}
