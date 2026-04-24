using SentinelCore.Api.Common.Abstractions;
using SentinelCore.Api.Domain.Entities;
using SentinelCore.Api.Infrastructure.Persistence;

namespace SentinelCore.Api.Feature.Metrics.RecordSystemMetrics;

public class RecordSystemMetricsHandler : ICommonHandler<RecordSystemMetricsRequest, RecordSystemMetricsResponse> {
	private readonly SentinelCoreDbContext _dbContext;
	private readonly ILogger<RecordSystemMetricsHandler> _logger;

	public RecordSystemMetricsHandler(SentinelCoreDbContext dbContext, ILogger<RecordSystemMetricsHandler> logger) {
		_dbContext = dbContext;
		_logger = logger;
	}
	
	public async Task<RecordSystemMetricsResponse> HandlerAsync(RecordSystemMetricsRequest request, CancellationToken ct = default) {
		try {
			var systemMetrics = new SystemMetrics(request.AgentId, request.HostName, request.OperatingSystem, request.CpuUsage, request.MemoryUsage, request.Timestamp);
			_dbContext.Add(systemMetrics);
			await _dbContext.SaveChangesAsync(ct);
			_logger.LogInformation("Metrics recorded successfully for Agent {AgentId}. RecordId: {RecordId}", request.AgentId, systemMetrics.Id);
			return new RecordSystemMetricsResponse( systemMetrics.Id );
		}
		catch(Exception ex) {
			_logger.LogError(ex, "Failed to record metrics for Agent {AgentId} on Host {HostName}", request.AgentId, request.HostName);
			throw;
		}
	}
}