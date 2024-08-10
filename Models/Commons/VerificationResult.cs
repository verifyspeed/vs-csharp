namespace VSCSharp.Models.Commons;

public record VerificationResult
{
	public string MethodName { get; set; } = null!;
	public DateTime DateOfVerification { get; set; }
	public string PhoneNumber { get; set; } = null!;
}