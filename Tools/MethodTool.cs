using VSCSharp.Constants;

namespace VSCSharp.Tools
{
	/// <summary>
	/// Provides extension methods for working with VerifySpeed verification method names.
	/// </summary>
	public static class MethodTool
	{
		/// <summary>
		/// Determines whether the specified method name represents an OTP-based verification method.
		/// </summary>
		/// <param name="methodName">
		/// The verification method name (for example, from <see cref="Models.Method.MethodName"/> or <see cref="MethodNames"/>).
		/// Comparison is case-insensitive.
		/// </param>
		/// <returns>
		/// <c>true</c> if <paramref name="methodName"/> is
		/// <see cref="MethodNames.SmsOtp"/>, <see cref="MethodNames.WhatsAppOtp"/>, or <see cref="MethodNames.TelegramOtp"/>;
		/// otherwise, <c>false</c>.
		/// </returns>
		public static bool IsOtpType(this string methodName)
		{
			string value = methodName.ToLower();
	
			if (value is MethodNames.SmsOtp or MethodNames.WhatsAppOtp or MethodNames.TelegramOtp)
			{
				return true;
			}
	
			return false;
		}
	}
}
