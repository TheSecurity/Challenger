using Challenger.Core.Repositories;
using Challenger.Core.Services;
using Challenger.Core.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Challenger.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
        => services.AddScoped<IChallengeRepository, ChallengeRepository>()
            .AddScoped<IChampionRepository, ChampionRepository>()
            .AddScoped<IChallengeService, ChallengeService>()
            .AddScoped<IChampionService, ChampionService>()
            .AddSingleton<IDbConnection, DbConnection>();
}
