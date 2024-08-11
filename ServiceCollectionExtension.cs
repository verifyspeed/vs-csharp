using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VSCSharp.Clients;

namespace VSCSharp
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddVerifySpeed(this IServiceCollection services, string serverKey)
		{
			services.AddScoped<IVerifySpeedClient>(
				_ =>
				{
					var httpClient = new HttpClient { BaseAddress = new Uri("https://api.verifyspeed.com") };
					httpClient.DefaultRequestHeaders.Add(name: "server-key", serverKey);

					return new VerifySpeedClient(httpClient);
				}
			);

			return services;
		}
	}
}