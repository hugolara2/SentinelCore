namespace SentinelCore.Api.Common.Abstractions;

public interface ICommonHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse> {
	Task<TResponse> HandlerAsync(TRequest request, CancellationToken ct = default);
}