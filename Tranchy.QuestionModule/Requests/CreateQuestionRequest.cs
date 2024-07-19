using Tranchy.QuestionModule.Data;

namespace Tranchy.QuestionModule.Requests;

public record CreateQuestionRequest(
    string Title,
    SupportLevel SupportLevel,
    string? PriorityId,
    string[] QuestionCategoryIds,
    bool? CommunityShareAgreement
);
