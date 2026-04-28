using SentinelCore.Api.Common.Abstractions;

namespace SentinelCore.Api.Infrastructure;

public class SentinelMediator : ISentinelMediator {
	private IServiceProvider _serviceProvider;

	public SentinelMediator(IServiceProvider serviceProvider) {
		_serviceProvider = serviceProvider;
	}
	
	public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken ct = default) {
		var requestType = request.GetType();

		var handlerType = typeof(ICommonHandler<,>).MakeGenericType(requestType, typeof(TResponse));
		dynamic handler = _serviceProvider.GetRequiredService(handlerType);
		return await handler.HandlerAsync((dynamic)request, ct);
	}
}