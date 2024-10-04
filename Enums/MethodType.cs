namespace VSCSharp.Enums
{
	/// <summary>
	/// Specifies the different methods available for verification process.
	/// </summary>
	public enum MethodType
	{
		/// <summary>
		/// Represents the method of using a verification message via Telegram.
		/// </summary>
		TelegramMessage,

		/// <summary>
		/// Represents the method of using a verification message via WhatsApp.
		/// </summary>
		WhatsAppMessage,

		/// <summary>
		/// Represents the method of sending a verification message via SMS with a one-time password (OTP).
		/// </summary>
		SmsOtp
	}
}