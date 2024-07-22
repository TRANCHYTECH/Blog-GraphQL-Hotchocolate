using Microsoft.Extensions.Hosting;

namespace Tranchy.Common
{
    public static class HostBuilderExtensions
    {
        public static async Task<int> RunWithCustomGraphQLCommandsAsync(this IHost host, string[] args)
        {
            var customArgs = args.IsGraphQLCommand() ? args.SkipWhile(a => !a.Equals("schema", StringComparison.Ordinal)).ToArray() : args;
            return await host.RunWithGraphQLCommandsAsync(customArgs);
        }

        public static bool IsGraphQLCommand(this string[] args) => args is ["schema", ..,];
    }
}
