using Microsoft.EntityFrameworkCore;
using SentinelCore.Api.Common.Abstractions;
using SentinelCore.Api.Common.Extensions;
using SentinelCore.Api.Feature.Metrics;
using SentinelCore.Api.Infrastructure;
using SentinelCore.Api.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SentinelDb");

builder.Services.AddDbContext<SentinelCoreDbContext>(opt => opt.UseNpgsql(connectionString));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpLogging(logging => {
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});

builder.Services.AddTransient<ISentinelMediator, SentinelMediator>();
builder.Services.AddFeatureHandlers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
    
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/openapi/v1.json", "SentinelCore API v1");
        options.RoutePrefix = string.Empty; // Hace que Swagger cargue directo en http://localhost:<puerto>/
    });
}

app.UseHttpsRedirection();
app.UseHttpLogging();

app.MapMetricsEndpoints();

app.Run();
