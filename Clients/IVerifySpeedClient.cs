using System.Threading.Tasks;
using VSCSharp.Enums;
using VSCSharp.Exceptions;
using VSCSharp.Models.Commons;

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
		/// <param name="verificationType">The type of verification to create (e.g., QR code, OTP).</param>
		/// <param name="language">The language to use for the verification process. Optional.</param>
		/// <returns>A <see cref="CreatedVerification"/> object that represents the created verification.</returns>
		/// <exception cref="FailedCreateVerificationException">Thrown when the verification creation fails.</exception>
		Task<CreatedVerification> CreateVerificationAsync(
			string methodName,
			string clientIPv4Address,
			VerificationType verificationType,
			string? language = null
		);

		/// <summary>
		/// Creates a verification.
		/// </summary>
		/// <param name="methodType">The method type to use for verification (e.g., <see cref="MethodType.TelegramMessage"/>).</param>
		/// <param name="clientIPv4Address">The client's IPv4 address to include in the request header.</param>
		/// <param name="verificationType">The type of verification to create (e.g., QR code, OTP).</param>
		/// <param name="language">The language to use for the verification process. Optional.</param>
		/// <returns>A <see cref="CreatedVerification"/> object that represents the created verification.</returns>
		/// <exception cref="FailedCreateVerificationException">Thrown when the verification creation fails.</exception>
		Task<CreatedVerification> CreateVerificationAsync(
			MethodType methodType,
			string clientIPv4Address,
			VerificationType verificationType,
			string? language = null
		);

		/// <summary>
		/// Verifies the token and returns the verification result.
		/// </summary>
		/// <param name="token">The token to verify.</param>
		/// <returns>A <see cref="VerificationResult"/> object that represents the verification result.</returns>
		/// <exception cref="FailedVerifyingTokenException">Thrown when the token verification fails.</exception>
		Task<VerificationResult> VerifyTokenAsync(string token);
	}
}