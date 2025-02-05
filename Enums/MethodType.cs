using VSCSharp.Constants;

namespace VSCSharp.Enums
{
	/// <summary>
	/// Enumeration representation of <see cref="MethodNames"/> values
	/// </summary>
	public enum MethodType
	{
		/// <summary>
		/// The enum value representing <see cref="MethodNames.TelegramMessage"/>.
		/// </summary>
		TelegramMessage,

		/// <summary>
		/// The enum value representing <see cref="MethodNames.WhatsAppMessage"/>.
		/// </summary>
		WhatsAppMessage,

		/// <summary>
		/// The enum value representing <see cref="MethodNames.SmsOtp"/>.
		/// </summary>
		SmsOtp,

		/// <summary>
		/// The enum value representing <see cref="MethodNames.WhatsAppOtp"/>.
		/// </summary>
		WhatsAppOtp,

		/// <summary>
		/// The enum value representing <see cref="MethodNames.TelegramOtp"/>.
		/// </summary>
		TelegramOtp
	}
}