using MongoDB.Entities;
using Tranchy.Common.Data;

namespace Tranchy.QuestionModule.Data;

[Collection("QuestionCategory")]
public class QuestionCategory : EntityBase
{
    public required string Key { get; init; }
    public required LocalizedString Title { get; init; }
    public required LocalizedString Description { get; init; }
}
