using System;
using System.Threading.Tasks;
using VSCSharp.Exceptions;
using VSCSharp.Models;

namespace VSCSharp.Clients
{
	/// <summary>
	/// A client for interacting with the VerifySpeed API to manage verifications.
	/// </summary>
	public interface IVerifySpeedClient
	{
		/// <summary>
		/// Initializes the verification process.
		/// </summary>
		/// <param name="clientIPv4Address">The client's IPv4 address to include in the request header.</param>
		/// <returns>An <see cref="Initialization"/> object that represents the initialization result.</returns>
		/// <exception cref="FailedInitializationException">Thrown when the initialization fails.</exception>
		Task<Initialization> InitializeAsync(string clientIPv4Address);

		/// <summary>
		/// Creates a verification.
		/// </summary>
		/// <param name="methodName">The method name to use for verification (e.g., "TelegramMessage", "WhatsAppMessage").</param>
		/// <param name="clientIPv4Address">The client's IPv4 address to include in the request header.</param>
		/// <param name="language">The language to use for the verification process. Optional.</param>
		/// <returns>A <see cref="CreatedVerificationResponse"/> object that represents the created verification.</returns>
		/// <exception cref="FailedCreateVerificationException">Thrown when the verification creation fails.</exception>
		Task<CreatedVerificationResponse> CreateVerificationAsync(
			string methodName,
			string clientIPv4Address,
			string? language = null
		);

		/// <summary>
		/// Verify verification token on VerifySpeed API.
		/// </summary>
		/// <param name="token">The token to verify.</param>
		/// <returns>A <see cref="VerifyTokenResponse"/> object that represents the API call response.</returns>
		/// <exception cref="FailedVerifyingTokenException">Thrown when the token verification fails.</exception>
		Task<VerifyTokenResponse> VerifyTokenAsync(string token);

		/// <summary>
		/// Decrypts the verification token and returns the result.
		/// </summary>
		/// <param name="token">The token to decrypt.</param>
		/// <returns>A <see cref="DecryptTokenResult"/> object that represents the result.</returns>
		DecryptTokenResult DecryptToken(string token);
	}
}