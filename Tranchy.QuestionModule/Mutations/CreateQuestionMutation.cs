using System.Security.Claims;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Entities;
using Tranchy.Common;
using Tranchy.QuestionModule.Data;
using Tranchy.QuestionModule.Inputs;
using Tranchy.QuestionModule.Outputs;

namespace Tranchy.QuestionModule.Mutations;

[MutationType]
public class CreateQuestionMutation
{
    // [Mobile] Or use [Tag("mobile")]
    [Error<NotFoundCategoryException>]
    public async Task<Question> CreateQuestion(CreateQuestionInput input,
        ClaimsPrincipal principal,
        [Service] ILogger<CreateQuestionMutation> logger)
    {
        var foundCategories = await DB.Collection<QuestionCategory>()
            .Find(c => input.CategoryKeys.Contains(c.Key))
            .Project(c => c.Key).ToListAsync();
        var notFoundCategories = input.CategoryKeys.Except(foundCategories).ToArray();
        if (notFoundCategories.Length != 0)
        {
            throw new NotFoundCategoryException(notFoundCategories);
        }

        var newQuestion = new Question
        {
            Title = input.Title,
            CreatedBy = principal.UserName(),
            SupportLevel = input.SupportLevel,
            PriorityKey = input.PriorityKey,
            CategoryKeys = input.CategoryKeys,
            CommunityShareAgreement = input.CommunityShareAgreement
        };
        await DB.InsertAsync(newQuestion);
        logger.LogInformation("new question created");

        return newQuestion;
    }
}