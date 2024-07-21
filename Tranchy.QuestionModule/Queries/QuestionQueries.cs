using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MongoDB.Entities;
using Tranchy.QuestionModule.Data;

namespace Tranchy.QuestionModule.Queries;

[QueryType]
public static class QuestionQueries
{
    public static IExecutable<Question> GetQuestions()
    {
        return DB.Collection<Question>().AsExecutable();
    }
}