namespace VSCSharp.Constants
{
	/// <summary>
	/// Machine-readable error codes returned in <see cref="Models.ValidateOtpResponse.ErrorCode"/> when OTP validation fails.
	/// </summary>
	public static class OtpErrorCodes
	{
		/// <summary>
		/// The OTP session has expired.
		/// </summary>
		public const string Expired = "OTP_EXPIRED";

		/// <summary>
		/// The provided code does not match.
		/// </summary>
		public const string Invalid = "OTP_INVALID";

		/// <summary>
		/// This verification was already completed.
		/// </summary>
		public const string AlreadyVerified = "OTP_ALREADY_VERIFIED";
	}
}
