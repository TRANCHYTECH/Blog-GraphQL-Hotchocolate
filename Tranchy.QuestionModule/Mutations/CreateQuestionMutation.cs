using HotChocolate.Types;
using MongoDB.Entities;
using Tranchy.Common.HotChocolate;
using Tranchy.QuestionModule.Data;
using Tranchy.QuestionModule.Requests;

namespace Tranchy.QuestionModule.Mutations
{
    [MutationType]
    public static class CreateQuestionMutation
    {
        [Mobile]
        //[Tag("mobile")]
        public static async Task<Question> CreateQuestion(CreateQuestionRequest request)
        {
            var newQuestion = new Question
            {
                Title = request.Title,
                CreatedBy = "user1@local.com",
                SupportLevel = request.SupportLevel,
                PriorityId = request.PriorityId,
                QuestionCategoryIds = request.QuestionCategoryIds,
                QueryIndex = 1
            };
            await DB.InsertAsync(newQuestion);

            return newQuestion;
        }
    }
}
