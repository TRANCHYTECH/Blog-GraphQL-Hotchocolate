using Microsoft.AspNetCore.Authentication.JwtBearer;
using Tranchy.QuestionModule;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
// builder.Services.AddScoped<ITenant, Tenant>();

builder.Services
    .AddGraphQLServer()
    .AllowIntrospection(allow: true)
    .AddAuthorization();

//todo: add Imodule
QuestionModuleStartup.ConfigureServices(builder.Services, builder.Configuration, builder.Environment);


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapBananaCakePop("/api/graphql/ui").AllowAnonymous();
app.MapGraphQLHttp("/api/graphql").RequireAuthorization();

await app.RunWithGraphQLCommandsAsync(args);
