namespace SentinelCore.Api.Common.Abstractions;

public interface ISentinelMediator {
	Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken ct = default);
}