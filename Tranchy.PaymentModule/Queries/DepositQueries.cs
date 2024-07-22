﻿using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Tranchy.PaymentModule.Data;

namespace Tranchy.PaymentModule.Queries;

[QueryType]
public static class DepositQueries
{
    public static async Task<Deposit?> GetDeposit(string questionId, [Service(ServiceKind.Synchronized)] PaymentDbContext dbContext, CancellationToken cancellation)
        => await dbContext.Deposits.AsNoTracking().FirstOrDefaultAsync(c => c.QuestionId == questionId, cancellation);

    public static IQueryable<Deposit> GetDeposits([Service(ServiceKind.Synchronized)] PaymentDbContext dbContext)
        => dbContext.Deposits.AsNoTracking().AsQueryable();
}