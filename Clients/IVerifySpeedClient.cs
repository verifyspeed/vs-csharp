using VSCSharp.Models.Results;

namespace VSCSharp.Clients;

public interface IVerifySpeedClient
{
	Task<InitializationResult> InitializeAsync();
}