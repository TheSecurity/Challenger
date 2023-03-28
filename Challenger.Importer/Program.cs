using Challenger.Core.Extensions;
using Challenger.Importer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, builder) =>
    {
        builder.AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
    })
    .ConfigureServices(services =>
    {
        services.AddCoreServices()
        .AddHostedService<InitialService>()
        .AddScoped<SynchronizationService>();
    })
    .Build();

await host.RunAsync();
