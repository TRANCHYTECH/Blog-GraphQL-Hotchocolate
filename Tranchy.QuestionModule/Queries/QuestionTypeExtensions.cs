using HotChocolate;
using HotChocolate.Types;
using Tranchy.QuestionModule.Data;

namespace Tranchy.QuestionModule.Queries
{
    [ExtendObjectType<Question>()]
    public static class QuestionTypeExtensions
    {
        public static async Task<IEnumerable<QuestionCategory>> QuestionCategories([Parent] Question question, IQuestionCategoriesDataLoader questionCategoriesDataLoader, CancellationToken cancellation)
        {
            var categories = await questionCategoriesDataLoader.LoadAsync(question.QuestionCategoryIds, cancellation);

            return categories;
        }
    }
}
