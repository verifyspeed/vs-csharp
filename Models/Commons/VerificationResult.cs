using System.Text.Json.Serialization;

namespace VSCSharp.Models.Commons;

public record VerificationResult
{
	[JsonPropertyName("methodName")]
	public string MethodName { get; set; } = null!;

	[JsonPropertyName("dateOfVerification")]
	public DateTime DateOfVerification { get; set; }

	[JsonPropertyName("phoneNumber")]
	public string PhoneNumber { get; set; } = null!;
}