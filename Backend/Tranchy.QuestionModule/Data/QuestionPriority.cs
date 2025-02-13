using MongoDB.Entities;
using Tranchy.Common.Data;

namespace Tranchy.QuestionModule.Data;

[Collection("QuestionPriorities")]
public class QuestionPriority : Entity, ICreatedOn, IModifiedOn
{
    public required string Key { get; set; }

    public LocalizedString Title { get; set; } = default!;

    public LocalizedString Description { get; set; } = default!;

    public int Rank { get; set; }

    public IDictionary<string, object> PriorityMetaData { get; set; } = default!;

    public TimeSpan Duration { get; set; } = default!;

    public DateTime CreatedOn { get; set; } = default!;

    public DateTime ModifiedOn { get; set; } = default!;
}
