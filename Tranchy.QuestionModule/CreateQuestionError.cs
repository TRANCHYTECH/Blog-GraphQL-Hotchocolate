namespace Tranchy.QuestionModule;


public class NotFoundCategoryException(string[] categoryKeys) : Exception("Invalid categories")
{
    public string[] CategoryKeys { get; } = categoryKeys;
}