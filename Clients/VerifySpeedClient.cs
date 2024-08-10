using System.Text.Json;
using VSCSharp.Exceptions;
using VSCSharp.Models.Results;

namespace VSCSharp.Clients;

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
	/// <returns><see cref="InitializationResult"/></returns>
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
				throw new FailedInitializationException(message: "response content is null");
			}

			return result;
		}
		catch (JsonException exception)
		{
			throw new FailedInitializationException(
				message: "Failed to deserialize the initialization response content",
				exception
			);
		}
	}
}