namespace VSCSharp.Exceptions;

public class FailedCreateVerificationException : Exception
{
	public FailedCreateVerificationException(string message) : base(message) { }
	public FailedCreateVerificationException(string message, Exception exception) : base(message, exception) { }
}