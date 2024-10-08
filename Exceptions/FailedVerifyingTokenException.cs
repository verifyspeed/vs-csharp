using System;

namespace VSCSharp.Exceptions
{
	/// <summary>
	/// Exception thrown when the verification of a token fails.
	/// </summary>
	public class FailedVerifyingTokenException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FailedVerifyingTokenException"/> class
		/// with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public FailedVerifyingTokenException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FailedVerifyingTokenException"/> class
		/// with a specified error message and a reference to the inner exception that caused this exception.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="exception">The exception that is the cause of this exception.</param>
		public FailedVerifyingTokenException(string message, Exception exception) : base(message, exception)
		{
		}
	}
}