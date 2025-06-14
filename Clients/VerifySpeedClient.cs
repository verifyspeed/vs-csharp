using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VSCSharp.Constants;
using VSCSharp.Exceptions;
using VSCSharp.Models.Commons;

namespace VSCSharp.Clients
{
	/// <inheritdoc/>
	public class VerifySpeedClient : IVerifySpeedClient
	{
		private readonly HttpClient httpClient;

		private static readonly JsonSerializerOptions JsonSerializerOptions = new()
		{
			PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		/// <summary>
		/// Initializes a new instance of the <see cref="VerifySpeedClient"/> class.
		/// </summary>
		/// <param name="httpClient">The HTTP client used for making API requests.</param>
		public VerifySpeedClient(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		/// <inheritdoc/>
		public async Task<Initialization> InitializeAsync(string clientIPv4Address)
		{
			httpClient.DefaultRequestHeaders.Add(name: LibraryConstants.ClientIPv4AddressHeaderName, clientIPv4Address);
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

		/// <inheritdoc/>
		public async Task<CreatedVerification> CreateVerificationAsync(
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

		/// <inheritdoc/>
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