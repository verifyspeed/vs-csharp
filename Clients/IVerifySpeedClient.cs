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
		/// <returns>An <see cref="InitializeResponse"/> object that represents the initialization result.</returns>
		/// <exception cref="FailedInitializationException">Thrown when the initialization fails.</exception>
		Task<InitializeResponse> InitializeAsync(string clientIPv4Address);

		/// <summary>
		/// Creates a verification.
		/// </summary>
		/// <param name="methodName">The verification method identifier (e.g., "whatsapp-message", "whatsapp-otp").</param>
		/// <param name="clientIPv4Address">The client's IPv4 address to include in the request header.</param>
		/// <param name="phoneNumber">The user's phone number in E.164 format (e.g., "+14255552673"). Required when <paramref name="methodName"/> is an OTP method ("whatsapp-otp", "telegram-otp", or "sms-otp"); VerifySpeed sends a one-time password to this number. Omit for message-based methods.</param>
		/// <param name="language">The language to use for the verification process (e.g., "en", "ar", "ckb"). Optional; defaults to English.</param>
		/// <returns>A <see cref="CreatedVerificationResponse"/> object that represents the created verification.</returns>
		/// <exception cref="FailedCreateVerificationException">Thrown when the verification creation fails.</exception>
		Task<CreatedVerificationResponse> CreateVerificationAsync(
			string methodName,
			string clientIPv4Address,
			string? phoneNumber = null,
			string? language = null
		);

		/// <summary>
		/// Validates an OTP code for a verification session created with an OTP method.
		/// Call from your backend when the user's app sends the code to your server (not from client apps with an exposed server key).
		/// </summary>
		/// <param name="code">The OTP code entered by the user (max 5 characters).</param>
		/// <param name="verificationKey">The verification key returned from <see cref="CreateVerificationAsync"/> for the same OTP session.</param>
		/// <returns>A <see cref="ValidateOtpResponse"/> object. Check <see cref="ValidateOtpResponse.Succeed"/>; business failures (invalid code, expired OTP) return HTTP 200 with <c>succeed: false</c>.</returns>
		/// <exception cref="FailedValidateOtpException">Thrown when the validate-otp HTTP request fails.</exception>
		Task<ValidateOtpResponse> ValidateOtpAsync(string code, string verificationKey);

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