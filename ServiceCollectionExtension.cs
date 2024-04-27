using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VSCSharp.Exceptions;
using VSCSharp.Models.Results;

namespace VSCSharp;

public static class ServiceCollectionExtension
{
	public static IServiceCollection AddVSCSharp(this IServiceCollection services, string serverKey)
	{
		services.TryAddSingleton<IVerifySpeedClient>(
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

public interface IVerifySpeedClient
{
	Task<InitializationResult> InitializeAsync();
}

public class VerifySpeedClient : IVerifySpeedClient
{
	private readonly HttpClient httpClient;

	public VerifySpeedClient(HttpClient httpClient)
	{
		this.httpClient = httpClient;
	}

	/// <summary>
	///   Initializes the verification process
	/// </summary>
	/// <returns>The initialization result</returns>
	/// <exception cref="FailedInitializationException">Thrown when the initialization fails</exception>
	public async Task<InitializationResult> InitializeAsync()
	{
		HttpResponseMessage response = await httpClient.GetAsync("v1/verifications/initialize");

		if (!response.IsSuccessStatusCode)
		{
			throw new FailedInitializationException($"Failed to initialize, reason: {response.ReasonPhrase}");
		}

		string content = await response.Content.ReadAsStringAsync();

		try
		{
			var result = JsonSerializer.Deserialize<InitializationResult>(content);

			if (result is null)
			{
				throw new FailedInitializationException(message: "content is null");
			}

			return result;
		}
		catch (Exception exception)
		{
			throw new FailedInitializationException(
				message: "Failed to deserialize the initialization result",
				exception
			);
		}
	}
}