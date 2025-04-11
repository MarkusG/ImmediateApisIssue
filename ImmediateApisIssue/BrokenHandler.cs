using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;

namespace ImmediateApisIssue;

[Handler]
[MapPost("/broken")]
public static partial class BrokenHandler
{
    public sealed record Command
    {
        public required HttpResponse Response { get; init; }
    }
    
    private static async ValueTask HandleAsync([AsParameters] Command command, CancellationToken token)
    {
        command.Response.ContentType = "text/event-stream";

        await command.Response.WriteAsync("event: myEvent\n");
        await command.Response.Body.FlushAsync();

        await Task.Delay(1000);
        await command.Response.WriteAsync("data: hello 1\n\n");
        await command.Response.Body.FlushAsync();

        await Task.Delay(1000);
        await command.Response.WriteAsync("data: hello 2\n\n");
        await command.Response.Body.FlushAsync();

        await command.Response.CompleteAsync();
    }
}