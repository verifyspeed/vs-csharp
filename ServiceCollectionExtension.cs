using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using VSCSharp.Clients;
using VSCSharp.Constants;

namespace VSCSharp
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddVerifySpeed(this IServiceCollection services, string serverKey)
		{
			services.AddScoped<IVerifySpeedClient>(
				_ =>
				{
					var httpClient = new HttpClient { BaseAddress = new Uri(LibraryConstants.ApiBaseUrl) };
					httpClient.DefaultRequestHeaders.Add(name: "server-key", serverKey);

					return new VerifySpeedClient(httpClient);
				}
			);

			return services;
		}
	}
}