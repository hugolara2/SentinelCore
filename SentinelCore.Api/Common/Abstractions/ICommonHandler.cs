namespace SentinelCore.Api.Common.Abstractions;

public interface ICommonHandler<in TRequest, TResponse> {
	Task<TResponse> HandlerAsync(TRequest request, CancellationToken ct = default);
}