namespace SentinelCore.Api.Common.Abstractions;

public interface ICommonHandler<in TRequest, TResponse> {
	Task<TResponse> Handle(TRequest request, CancellationToken ct = default);
}