using System.Text.Json.Serialization;

namespace VSCSharp.Models.Commons
{
	/// <summary>
	/// Represents the result of a created verification request.
	/// </summary>
	public record CreatedVerification
	{
		/// <summary>
		/// Gets the name of the verification method (e.g., "whatsapp-message").
		/// </summary>
		[JsonPropertyName("MethodName")]
		public string MethodName { get; init; } = null!;

		/// <summary>
		/// Gets the unique key associated with the created verification.
		/// </summary>
		[JsonPropertyName("verificationKey")]
		public string VerificationKey { get; init; } = null!;

		/// <summary>
		/// Gets the deep link used for the verification process, if applicable.
		/// This can be <c>null</c> if the verification method does not use deep links.
		/// </summary>
		[JsonPropertyName("deepLink")]
		public string? DeepLink { get; init; }

		/// <summary>
		/// Gets the URL of the QR code image associated with the verification, if applicable.
		/// This can be <c>null</c> if the verification method does not use a QR code.
		/// </summary>
		[JsonPropertyName("qrCodeImage")]
		public string? QrCodeImage { get; init; }
	}
}