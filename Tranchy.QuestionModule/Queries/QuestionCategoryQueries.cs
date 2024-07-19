using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MongoDB.Entities;
using Tranchy.QuestionModule.Data;

namespace Tranchy.QuestionModule.Queries
{
    [QueryType]
    public static class QuestionCategoryQueries
    {
        public static IExecutable<QuestionCategory> GetQuestionCategories()
        {
            return DB.Collection<QuestionCategory>().AsExecutable();
        }
    }
}
