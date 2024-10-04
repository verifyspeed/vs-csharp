using System;

namespace VSCSharp.Exceptions
{
	/// <summary>
	/// Exception thrown when initialization of the verification process fails.
	/// </summary>
	public class FailedInitializationException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FailedInitializationException"/> class with a specified error message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public FailedInitializationException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FailedInitializationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="exception">The exception that caused the current exception.</param>
		public FailedInitializationException(string message, Exception exception) : base(message, exception)
		{
		}
	}
}