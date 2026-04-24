using SentinelCore.Api.Common.Abstractions;

namespace SentinelCore.Api.Feature.Metrics.RecordSystemMetrics;

public record RecordSystemMetricsRequest(
	Guid AgentId,
	string HostName,
	string OperatingSystem,
	double CpuUsage,
	double MemoryUsage,
	DateTimeOffset Timestamp
) : IRequest<RecordSystemMetricsResponse>;