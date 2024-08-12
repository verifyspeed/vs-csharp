using System.Threading.Tasks;
using VSCSharp.Enums;
using VSCSharp.Models.Commons;

namespace VSCSharp.Clients
{
	public interface IVerifySpeedClient
	{
		Task<Initialization> InitializeAsync(string clientIpAddress);

		Task<CreatedVerification> CreateVerificationAsync(
			string methodName,
			string clientIpAddress,
			VerificationType verificationType
		);
	
		Task<VerificationResult> VerifyTokenAsync(string token);
	}
}