using System.Net.Mime;
using System.Text;
using System.Text.Json;
using VSCSharp.Enums;
using VSCSharp.Exceptions;
using VSCSharp.Models.Commons;

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
	/// <returns><see cref="Initialization"/></returns>
	/// <exception cref="FailedInitializationException">Thrown when the initialization fails</exception>
	public async Task<Initialization> InitializeAsync()
	{
		HttpResponseMessage response = await httpClient.GetAsync("v1/verifications/initialize");

		if (!response.IsSuccessStatusCode)
		{
			throw new FailedInitializationException($"Failed to initialize, reason: {response.ReasonPhrase}");
		}

		string content = await response.Content.ReadAsStringAsync();

		try
		{
			var result = JsonSerializer.Deserialize<Initialization>(content);

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

	public async Task<CreatedVerification> CreateVerificationAsync(
		string methodName,
		string clientIpAddress,
		VerificationType verificationType
	)
	{
		HttpResponseMessage response = await httpClient.PostAsync(
			requestUri: "v1/verifications/create",
			new StringContent(
				JsonSerializer.Serialize(
					new
					{
						methodName,
						clientIpAddress,
						deepLink = verificationType == VerificationType.DeepLink,
						qrCode = verificationType == VerificationType.QrCode
					}
				),
				Encoding.UTF8,
				MediaTypeNames.Application.Json
			)
		);

		if (!response.IsSuccessStatusCode)
		{
			throw new FailedCreateVerificationException(
				$"Failed to create verification, reason: {response.ReasonPhrase}"
			);
		}

		string content = await response.Content.ReadAsStringAsync();

		try
		{
			var result = JsonSerializer.Deserialize<CreatedVerification>(content);

			if (result is null)
			{
				throw new FailedCreateVerificationException(message: "response content is null");
			}

			return result;
		}
		catch (JsonException exception)
		{
			throw new FailedCreateVerificationException(
				message: "Failed to deserialize the create verification response content",
				exception
			);
		}
	}
}