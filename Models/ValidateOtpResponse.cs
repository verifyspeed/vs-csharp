using System.Text.Json.Serialization;

namespace VSCSharp.Models
{
	/// <summary>
	/// Represents the result of validating an OTP code via the VerifySpeed backend API.
	/// </summary>
	public record ValidateOtpResponse
	{
		/// <summary>
		/// Gets whether the OTP code is valid for the given verification key.
		/// </summary>
		[JsonPropertyName("succeed")]
		public bool Succeed { get; init; }

		/// <summary>
		/// Gets the verification token when <see cref="Succeed"/> is <c>true</c>; otherwise <c>null</c>.
		/// Decrypt locally or call <see cref="Clients.IVerifySpeedClient.VerifyTokenAsync"/> for full verification details.
		/// </summary>
		[JsonPropertyName("token")]
		public string? Token { get; init; }

		/// <summary>
		/// Gets the verified phone number in E.164 format when <see cref="Succeed"/> is <c>true</c>; otherwise <c>null</c>.
		/// </summary>
		[JsonPropertyName("phoneNumber")]
		public string? PhoneNumber { get; init; }

		/// <summary>
		/// Gets a human-readable error description when <see cref="Succeed"/> is <c>false</c>; otherwise <c>null</c>.
		/// </summary>
		[JsonPropertyName("errorMessage")]
		public string? ErrorMessage { get; init; }

		/// <summary>
		/// Gets a machine-readable error code when <see cref="Succeed"/> is <c>false</c>; otherwise <c>null</c>.
		/// Known values: <see cref="Constants.OtpErrorCodes.Expired"/>, <see cref="Constants.OtpErrorCodes.Invalid"/>, <see cref="Constants.OtpErrorCodes.AlreadyVerified"/>.
		/// </summary>
		[JsonPropertyName("errorCode")]
		public string? ErrorCode { get; init; }
	}
}
