namespace VSCSharp.Exceptions;

public class FailedInitializationException : Exception
{
	public FailedInitializationException(string message) : base(message) { }
	public FailedInitializationException(string message, Exception exception) : base(message, exception) { }
}

public class FailedCreateVerificationException : Exception
{
	public FailedCreateVerificationException(string message) : base(message) { }
	public FailedCreateVerificationException(string message, Exception exception) : base(message, exception) { }
}