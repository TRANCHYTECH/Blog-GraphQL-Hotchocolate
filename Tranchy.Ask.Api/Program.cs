using Microsoft.AspNetCore.Authentication.JwtBearer;
using Tranchy.QuestionModule;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHttpContextAccessor()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services
    .AddGraphQLServer()
    .AddMutationConventions()
    .AllowIntrospection(allow: true)
    .AddAuthorization();

//todo: add IModule
QuestionModuleStartup.ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapBananaCakePop("/api/graphql/ui").AllowAnonymous();
app.MapGraphQLHttp("/api/graphql").RequireAuthorization();

await app.RunWithGraphQLCommandsAsync(args);
