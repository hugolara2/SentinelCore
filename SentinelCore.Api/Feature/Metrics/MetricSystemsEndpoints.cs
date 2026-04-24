using SentinelCore.Api.Common.Abstractions;
using SentinelCore.Api.Feature.Metrics.RecordSystemMetrics;

namespace SentinelCore.Api.Feature.Metrics;

public static class MetricSystemsEndpoints {
	public static void MapMetricsEndpoints(this IEndpointRouteBuilder app)
	{
		// 1. Agrupamos todo bajo "/api/metrics"
		var group = app.MapGroup("/api/metrics")
			.WithTags("System Metrics"); 

		group.MapPost("/", async (RecordSystemMetricsRequest request, ISentinelMediator mediator, CancellationToken ct) => {
			var response = await mediator.SendAsync(request, ct);
			return Results.Ok(response);
		});
	}
}