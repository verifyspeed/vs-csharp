namespace VSCSharp.Constants
{
	/// <summary>
	/// Contains constant string values representing the names of different methods used in the verification process.
	/// </summary>
	public class MethodNames
	{
		/// <summary>
		/// Represents the method of using Telegram message in the verification process.
		/// </summary>
		public const string TelegramMessage = "telegram-message";

		/// <summary>
		/// Represents the method of using WhatsApp message in the verification process.
		/// </summary>
		public const string WhatsAppMessage = "whatsapp-message";

		/// <summary>
		/// Represents the method of sending a verification code via SMS.
		/// </summary>
		public const string SmsOtp = "sms-otp";

		/// <summary>
		/// Represents the method of sending a verification code via WhatsApp
		/// </summary>
		public const string WhatsAppOtp = "whatsapp-otp";

		/// <summary>
		/// Represents the method of sending a verification code via Telegram
		/// </summary>
		public const string TelegramOtp = "telegram-otp";

		/// <summary>
		/// Represents the method of sending a verification code via available channel
		/// </summary>
		public const string DynamicOtp = "dynamic-otp";
	}
}