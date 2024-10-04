using System.Threading.Tasks;
using VSCSharp.Enums;
using VSCSharp.Models.Commons;

namespace VSCSharp.Clients
{
	public interface IVerifySpeedClient
	{
		Task<Initialization> InitializeAsync(string clientIPv4Address);

		Task<CreatedVerification> CreateVerificationAsync(
			string methodName,
			string clientIPv4Address,
			VerificationType verificationType,
			string phoneNumber = null
		);
	
		Task<VerificationResult> VerifyTokenAsync(string token);
	}
}