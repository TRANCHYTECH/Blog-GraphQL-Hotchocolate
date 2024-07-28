using HotChocolate;
using HotChocolate.Types;
using Tranchy.Common.HotChocolate;
using Tranchy.QuestionModule.Data;

namespace Tranchy.QuestionModule.Subscriptions;

[SubscriptionType]
public static class QuestionSubscriptions
{
    [Subscribe]
    [Web]
    public static Question QuestionCreated([EventMessage] Question question) => question;
}