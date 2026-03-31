using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VSCSharp.Constants;
using VSCSharp.Exceptions;
using VSCSharp.Models;
using VSCSharp.Tools;

namespace VSCSharp.Clients
{
	/// <inheritdoc/>
	internal class VerifySpeedClient : IVerifySpeedClient
	{
		private string ServerKey { get; }
		private readonly HttpClient httpClient;

		private static readonly JsonSerializerOptions JsonSerializerOptions = new()
		{
			PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		/// <summary>
		/// Initializes a new instance of the <see cref="VerifySpeedClient"/> class.
		/// </summary>
		/// <param name="httpClient">The HTTP client used for making API requests.</param>
		/// <param name="serverKey"></param>
		internal VerifySpeedClient(HttpClient httpClient, string serverKey)
		{
			ServerKey = serverKey;
			this.httpClient = httpClient;
		}

		/// <inheritdoc/>
		public async Task<InitializeResponse> InitializeAsync(string clientIPv4Address)
		{
			httpClient.DefaultRequestHeaders.Add(name: LibraryConstants.ClientIPv4AddressHeaderName, clientIPv4Address);
			HttpResponseMessage response = await httpClient.GetAsync("v1/verifications/initialize");
			string content = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
			{
				throw new FailedInitializationException(
					$"Failed to initialize, status code: {response.StatusCode}, reason: {response.ReasonPhrase}, content: {content}"
				);
			}

			try
			{
				var result = JsonSerializer.Deserialize<InitializeResponse>(content, JsonSerializerOptions);

				if (result is null)
				{
					throw new FailedInitializationException(
						message: "Failed to deserialize the initialization response content"
					);
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

		/// <inheritdoc/>
		public async Task<CreatedVerificationResponse> CreateVerificationAsync(
			string methodName,
			string clientIPv4Address,
			string? language = null
		)
		{
			httpClient.DefaultRequestHeaders.Add(name: LibraryConstants.ClientIPv4AddressHeaderName, clientIPv4Address);

			HttpResponseMessage response = await httpClient.PostAsync(
				requestUri: "v1/verifications/create",
				new StringContent(
					JsonSerializer.Serialize(
						new { methodName = methodName, language = language },
						JsonSerializerOptions
					),
					Encoding.UTF8,
					MediaTypeNames.Application.Json
				)
			);

			string content = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
			{
				throw new FailedCreateVerificationException(
					$"Failed to create verification, status code: {response.StatusCode}, reason: {response.ReasonPhrase}, content: {content}"
				);
			}

			try
			{
				var result = JsonSerializer.Deserialize<CreatedVerificationResponse>(content, JsonSerializerOptions);

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

		/// <inheritdoc/>
		public async Task<VerifyTokenResponse> VerifyTokenAsync(string token)
		{
			httpClient.DefaultRequestHeaders.Add(name: "token", token);
			HttpResponseMessage responseMessage = await httpClient.GetAsync("v1/verifications/result");

			string content = await responseMessage.Content.ReadAsStringAsync();

			if (!responseMessage.IsSuccessStatusCode)
			{
				throw new FailedVerifyingTokenException(
					$"Failed to verify token, status code: {responseMessage.StatusCode}, reason: {responseMessage.ReasonPhrase}, content: {content}"
				);
			}

			try
			{
				var response =
					JsonSerializer.Deserialize<VerifyTokenResponse>(content, JsonSerializerOptions);

				return response ?? throw new FailedVerifyingTokenException(message: "response content is null");
			}
			catch (JsonException exception)
			{
				throw new FailedVerifyingTokenException(
					message: "Failed to deserialize the verification result response content",
					exception
				);
			}
		}

		/// <inheritdoc/>
		public DecryptTokenResult DecryptToken(string token)
		{
			DecryptTokenResult result = token.DecryptToken(ServerKey);

			return result;
		}
	}
}