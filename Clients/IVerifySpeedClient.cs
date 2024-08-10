using VSCSharp.Enums;
using VSCSharp.Models.Commons;

namespace VSCSharp.Clients;

public interface IVerifySpeedClient
{
	Task<Initialization> InitializeAsync();

	Task<CreatedVerification> CreateVerificationAsync(
		string methodName,
		string clientIpAddress,
		VerificationType verificationType
	);
	
	Task<VerificationResult> VerifyTokenAsync(string token);
}