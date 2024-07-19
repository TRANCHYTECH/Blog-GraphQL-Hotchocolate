using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MongoDB.Entities;
using Tranchy.QuestionModule.Data;

namespace Tranchy.QuestionModule.Queries
{
    [QueryType]
    public static class QuestionQueries
    {
        public static IExecutable<Question> GetQuestions()
        {
            return DB.Collection<Question>().AsExecutable();
        }

        [DataLoader]
        public static async Task<IReadOnlyDictionary<string, QuestionCategory>> GetQuestionCategories(IReadOnlyList<string> ids, CancellationToken cancellationToken)
        {
            var categories = await DB.Find<QuestionCategory>().Match(c => ids.Contains(c.ID)).ExecuteAsync(cancellationToken);

            return categories.ToDictionary(c => c.ID);
        }
    }
}
