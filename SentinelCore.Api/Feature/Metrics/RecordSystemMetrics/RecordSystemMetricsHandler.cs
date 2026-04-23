using SentinelCore.Api.Common.Abstractions;

namespace SentinelCore.Api.Feature.Metrics.RecordSystemMetrics;

public class RecordSystemMetricsHandler : ICommonHandler<RecordSystemMetricsRequest, RecordSystemMetricsResponse> {
	
	public Task<RecordSystemMetricsResponse> HandlerAsync(RecordSystemMetricsRequest request, CancellationToken ct = default) {
		throw new NotImplementedException();
	}
}