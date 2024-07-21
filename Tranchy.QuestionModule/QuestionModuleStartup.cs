using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Entities;
using Tranchy.QuestionModule.Data;
using Microsoft.Extensions.Logging;
using MongoDB.Driver.Core.Configuration;

namespace Tranchy.QuestionModule;

public static class QuestionModuleStartup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment)
    {
        var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };

        ConventionRegistry.Register("TranchyAskDefaultConventions", conventionPack, _ => true);
        var conn = MongoClientSettings.FromConnectionString(configuration.GetConnectionString("Question"));

        using var loggerFactory = LoggerFactory.Create(b =>
        {
            b.AddSimpleConsole();
            b.AddConfiguration(configuration.GetSection("Logging"));
            b.SetMinimumLevel(LogLevel.Debug);
        });
        conn.LoggingSettings = new LoggingSettings(loggerFactory);

        DB.InitAsync("question", conn).Wait(cancellationToken: default);
        DB.DatabaseFor<Question>("question");
        DB.DatabaseFor<QuestionCategory>("question");
        DB.DatabaseFor<QuestionPriority>("question");

        var hotChocolateBuilder = services.AddGraphQL();
        hotChocolateBuilder
            .AddQuestionModuleTypes()
            .AddMongoDbSorting()
            .AddMongoDbFiltering()
            .AddMongoDbPagingProviders();
    }
}