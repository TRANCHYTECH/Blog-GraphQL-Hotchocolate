using DnsClient;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Tranchy.PaymentModule.Data;

namespace Tranchy.PaymentModule.Queries;

[QueryType]
public static class DepositQueries
{
    [AllowAnonymous]
    public static string Ping(string questionId) => $"{questionId} 10$";

    public static async Task<Deposit?> Deposit(string questionId, [Service(ServiceKind.Synchronized)] PaymentDbContext dbContext, CancellationToken cancellation)
    {
        return await dbContext.Deposits.AsNoTracking().FirstOrDefaultAsync(c => c.QuestionId == questionId, cancellation);
    }

    public static IQueryable<Deposit> Deposits([Service(ServiceKind.Synchronized)] PaymentDbContext dbContext, CancellationToken cancellation)
    {
        return dbContext.Deposits.AsNoTracking().AsQueryable();
    }
}