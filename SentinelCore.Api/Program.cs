using SentinelCore.Api.Common.Abstractions;
using SentinelCore.Api.Common.Extensions;
using SentinelCore.Api.Feature.Metrics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<ISentinelMediator, ISentinelMediator>();
builder.Services.AddFeatureHandlers();

var app = builder.Build();

app.MapMetricsEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
