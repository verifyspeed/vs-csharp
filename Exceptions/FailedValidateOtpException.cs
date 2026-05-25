using System;

namespace VSCSharp.Exceptions
{
	/// <summary>
	/// Exception thrown when the validate-otp API request fails (non-success HTTP status).
	/// </summary>
	public class FailedValidateOtpException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FailedValidateOtpException"/> class
		/// with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public FailedValidateOtpException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FailedValidateOtpException"/> class
		/// with a specified error message and a reference to the inner exception that caused this exception.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="exception">The exception that is the cause of this exception.</param>
		public FailedValidateOtpException(string message, Exception exception) : base(message, exception)
		{
		}
	}
}
