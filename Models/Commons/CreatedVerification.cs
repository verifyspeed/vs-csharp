using System.Text.Json.Serialization;

namespace VSCSharp.Models.Commons
{
	public record CreatedVerification
	{
		[JsonPropertyName("MethodName")]
		public string MethodName { get; set; } = null!;
		
		[JsonPropertyName("verificationKey")]
		public string VerificationKey { get; set; } = null!;

		[JsonPropertyName("deepLink")]
		public string? DeepLink { get; set; }

		[JsonPropertyName("qrCodeImage")]
		public string? QrCodeImage { get; set; }
	}
}