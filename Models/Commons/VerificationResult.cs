using System;
using System.Text.Json.Serialization;

namespace VSCSharp.Models.Commons
{
	/// <summary>
	/// Represents the result of a verification process, including the method used, 
	/// the date of verification, and the verified phone number.
	/// </summary>
	public record VerificationResult
	{
		/// <summary>
		/// Gets the name of the verification method used.
		/// For example, "whatsapp-message", or "sms-otp".
		/// </summary>
		[JsonPropertyName("methodName")]
		public string MethodName { get; init; } = null!;

		/// <summary>
		/// Gets the date and time when the verification was completed.
		/// </summary>
		[JsonPropertyName("dateOfVerification")]
		public DateTime DateOfVerification { get; init; }

		/// <summary>
		/// Gets the verified phone number.
		/// </summary>
		[JsonPropertyName("phoneNumber")]
		public string PhoneNumber { get; init; } = null!;
	}
}