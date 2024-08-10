namespace VSCSharp.Models.Commons;

public record CreatedVerification
{
	public string VerificationKey { get; set; } = null!;
	public string? DeepLink { get; set; }
	public string? QrCodeImage { get; set; }
}