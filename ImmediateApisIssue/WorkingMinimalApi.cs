namespace ImmediateApisIssue;

public static class WorkingMinimalApi
{
    public static void MapWorkingMinimalApi(this IEndpointRouteBuilder app)
    {
        app.MapPost("/working", async (HttpResponse response) =>
        {
            response.ContentType = "text/event-stream";

            await response.WriteAsync("event: myEvent\n");
            await response.Body.FlushAsync();

            await Task.Delay(1000);
            await response.WriteAsync("data: hello 1\n\n");
            await response.Body.FlushAsync();
            
            await Task.Delay(1000);
            await response.WriteAsync("data: hello 2\n\n");
            await response.Body.FlushAsync();

            await response.CompleteAsync();
        });
    }
}