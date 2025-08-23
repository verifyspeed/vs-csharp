using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using VSCSharp.Clients;
using VSCSharp.Constants;

namespace VSCSharp
{
	/// <summary>
	/// Provides extension methods for adding the VerifySpeed services to an <see cref="IServiceCollection"/>.
	/// </summary>
	public static class ServiceCollectionExtension
	{
		/// <summary>
		/// Registers the VerifySpeed services with the specified server key.
		/// </summary>
		/// <param name="services">The service collection to which the VerifySpeed services will be added.</param>
		/// <param name="serverKey">The server key used for authentication with the VerifySpeed API.</param>
		/// <returns>The updated <see cref="IServiceCollection"/> with VerifySpeed services registered.</returns>
		public static IServiceCollection AddVerifySpeed(this IServiceCollection services, string serverKey)
		{
			services.AddScoped<IVerifySpeedClient>(
				_ =>
				{
					var httpClient = new HttpClient { BaseAddress = new Uri(LibraryConstants.ApiBaseUrl) };
					httpClient.DefaultRequestHeaders.Add(name: "server-key", serverKey);

					return new VerifySpeedClient(httpClient, serverKey);
				}
			);

			return services;
		}
	}
}