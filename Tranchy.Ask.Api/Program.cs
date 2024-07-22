using Microsoft.AspNetCore.Authentication.JwtBearer;
using Tranchy.Common;
using Tranchy.QuestionModule;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddHttpContextAccessor()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services
    .AddGraphQLServer()
    .AddMutationConventions()
    .AllowIntrospection(allow: true)
    .AddAuthorization();

QuestionModuleStartup.ConfigureServices(builder.Services, configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

if (configuration.GetValue<bool>("EnableBananaCakePop"))
{
    app.MapBananaCakePop("/api/graphql/ui").AllowAnonymous();
}
app.MapGraphQLHttp("/api/graphql").RequireAuthorization();

if (!args.IsGraphQlCommand())
{
    await QuestionModuleStartup.InitDatabase(configuration);
}

if (app.Configuration.GetValue<bool>("ApplyMigrationsOnStartup"))
{
    await using var scope = app.Services.CreateAsyncScope();
    await QuestionModuleStartup.MigrateDatabase(scope.ServiceProvider);
}

await app.RunWithCustomGraphQlCommandsAsync(args);
