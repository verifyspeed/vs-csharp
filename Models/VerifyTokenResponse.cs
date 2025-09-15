using System;
using System.Text.Json.Serialization;

namespace VSCSharp.Models;

/// <summary>
/// Represents the result of a verification process
/// </summary>
public record VerifyTokenResponse
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

	/// <summary>
	/// Gets the verification key.
	/// </summary>
	[JsonPropertyName("verificationKey")]
	public string VerificationKey { get; init; } = null!;

	/// <summary>
	/// Indicates whether this is the first time the token has been verified. False means it has been verified before by VerifySpeed.
	/// </summary>
	[JsonPropertyName("firstTimeVerified")]
	public string FirstTimeVerified { get; init; } = null!;
}