using Challenger.Importer.Services;
using Challenger.Storage;
using Challenger.Storage.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<ChallengeService>()
        .AddScoped<ChampionService>()
        .AddScoped<IDbConnection, DbConnection>()
        .AddScoped<IChallengeRepository, ChallengeRepository>()
        .AddScoped<IChampionRepository, ChampionRepository>()
        .AddHostedService<SynchronizationService>();
    })
    .Build();

await host.RunAsync();
