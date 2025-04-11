using ImmediateApisIssue;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddImmediateApisIssueBehaviors();
builder.Services.AddImmediateApisIssueHandlers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapWorkingMinimalApi();
app.MapImmediateApisIssueEndpoints();

app.Run();