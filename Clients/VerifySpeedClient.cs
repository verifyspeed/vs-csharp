using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VSCSharp.Enums;
using VSCSharp.Exceptions;
using VSCSharp.Models.Commons;

namespace VSCSharp.Clients
{
	public class VerifySpeedClient : IVerifySpeedClient
	{
		private readonly HttpClient httpClient;

		private static readonly JsonSerializerOptions JsonSerializerOptions = new()
		{
			PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		public VerifySpeedClient(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		/// <summary>
		/// Initializes the verification process
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
				var result = JsonSerializer.Deserialize<Initialization>(content, JsonSerializerOptions);

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

		/// <summary>
		/// Creates a verification
		/// </summary>
		/// <param name="methodName">The method name to use for verification</param>
		/// <param name="clientIpAddress">The client's IP address</param>
		/// <param name="verificationType">The type of verification to create</param>
		/// <returns></returns>
		/// <exception cref="FailedCreateVerificationException"></exception>
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
						},
						JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<CreatedVerification>(content, JsonSerializerOptions);

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

		/// <summary>
		/// Verifies the token and returns the result
		/// </summary>
		/// <param name="token">The token to verify </param>
		/// <returns><see cref="VerificationResult"/></returns>
		/// <exception cref="FailedVerifyingTokenException"></exception>
		public async Task<VerificationResult> VerifyTokenAsync(string token)
		{
			httpClient.DefaultRequestHeaders.Add(name: "token", token);
			HttpResponseMessage response = await httpClient.GetAsync("v1/verifications/result");

			if (!response.IsSuccessStatusCode)
			{
				throw new FailedVerifyingTokenException($"Failed to verify token, reason: {response.ReasonPhrase}");
			}

			string content = await response.Content.ReadAsStringAsync();

			try
			{
				var result = JsonSerializer.Deserialize<VerificationResult>(content, JsonSerializerOptions);

				if (result is null)
				{
					throw new FailedVerifyingTokenException(message: "response content is null");
				}

				return result;
			}
			catch (JsonException exception)
			{
				throw new FailedVerifyingTokenException(
					message: "Failed to deserialize the verification result response content",
					exception
				);
			}
		}
	}
}