using Microsoft.AspNetCore.Authentication.JwtBearer;
using Tranchy.PaymentModule;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
services.AddGraphQLServer().AllowIntrospection(allow: true).AddAuthorization();

PaymentModule.ConfigureServices(services, builder.Configuration);

var app = builder.Build();

if (app.Configuration.GetValue<bool>("ApplyMigrationsOnStartup"))
{
    await using var scope = app.Services.CreateAsyncScope();
    await PaymentModule.MigrateDatabase(scope.ServiceProvider);
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapBananaCakePop("/api/graphql/ui").AllowAnonymous();
app.MapGraphQLHttp("/api/graphql").RequireAuthorization();

await app.RunWithGraphQLCommandsAsync(args);
