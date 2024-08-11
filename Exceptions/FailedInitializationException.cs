using System;

namespace VSCSharp.Exceptions
{
	public class FailedInitializationException : Exception
	{
		public FailedInitializationException(string message) : base(message) { }
		public FailedInitializationException(string message, Exception exception) : base(message, exception) { }
	}
}