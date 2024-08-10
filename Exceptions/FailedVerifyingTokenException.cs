namespace VSCSharp.Exceptions;

public class FailedVerifyingTokenException : Exception
{
	public FailedVerifyingTokenException(string message) : base(message) { }
	public FailedVerifyingTokenException(string message, Exception exception) : base(message, exception) { }
}