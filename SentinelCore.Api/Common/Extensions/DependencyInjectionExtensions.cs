using System.Reflection;
using SentinelCore.Api.Common.Abstractions;

namespace SentinelCore.Api.Common.Extensions;

public static class DependencyInjectionExtensions {
	public static IServiceCollection AddFeatureHandlers(this IServiceCollection services) {
		var assembly = Assembly.GetExecutingAssembly();

		var handlerTypes = assembly.GetTypes()
			.Where(type => type.IsClass && !type.IsAbstract)
			.SelectMany(type => type.GetInterfaces(), (type, iface) => new { type, iface })
			.Where(x => x.iface.IsGenericType && x.iface.GetGenericTypeDefinition() == typeof(ICommonHandler<,>));

		foreach (var match in handlerTypes) {
			// match.iface = ICommonHandler<RecordSystemMetricsRequest, RecordSystemMetricsResponse>
			// match.type  = RecordSystemMetricsHandler
			services.AddTransient(match.iface, match.type);
		}
		
		return services;
	}
}