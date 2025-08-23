using System;

namespace VSCSharp.Exceptions
{
	/// <summary>
	/// Exception thrown when a verification token is invalid or cannot be decrypted.
	/// </summary>
	public class InvalidVerificationTokenException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidVerificationTokenException"/> class
		/// with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public InvalidVerificationTokenException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidVerificationTokenException"/> class
		/// with a specified error message and a reference to the inner exception that caused this exception.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="exception">The exception that is the cause of this exception.</param>
		public InvalidVerificationTokenException(string message, Exception exception) : base(message, exception)
		{
		}
	}
}