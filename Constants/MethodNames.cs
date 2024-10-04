namespace VSCSharp.Constants
{
	/// <summary>
	/// Contains constant string values representing the names of different methods used in the verification process.
	/// </summary>
	public class MethodNames
	{
		/// <summary>
		/// The string value representing the method name for sending verification messages via Telegram.
		/// </summary>
		public const string TelegramMessage = "telegram-message";

		/// <summary>
		/// The string value representing the method name for sending verification messages via WhatsApp.
		/// </summary>
		public const string WhatsAppMessage = "whatsapp-message";

		/// <summary>
		/// The string value representing the method name for sending verification messages via SMS with a one-time password (OTP).
		/// </summary>
		public const string SmsOtp = "sms-otp";
	}

}