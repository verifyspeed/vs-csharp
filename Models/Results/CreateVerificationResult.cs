namespace VSCSharp.Models.Results;

public record CreateVerificationResult
{
	public string VerificationKey { get; set; } = null!;
	public string? DeepLink { get; set; }
	public string? QrCodeImage { get; set; }
}