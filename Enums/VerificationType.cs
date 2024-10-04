namespace VSCSharp.Enums
{
	/// <summary>
	/// Specifies the different types of verification.
	/// </summary>
	public enum VerificationType
	{
		/// <summary>
		/// Represents a verification type using a deep link.
		/// </summary>
		DeepLink,

		/// <summary>
		/// Represents a verification type using a QR code.
		/// </summary>
		QRCode,

		/// <summary>
		/// Represents a verification type using a one-time password (OTP).
		/// </summary>
		OTP
	}
}