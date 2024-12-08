using System;
using VSCSharp.Constants;
using VSCSharp.Enums;

namespace VSCSharp.Tools
{
	/// <summary>
	/// Provides extension methods for converting between enums and their corresponding string values.
	/// </summary>
	public static class Convertors
	{
		/// <summary>
		/// Converts a <see cref="MethodType"/> to its corresponding string value.
		/// </summary>
		/// <param name="methodType">The method type to convert.</param>
		/// <returns>A string representing the method type.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Thrown when an unsupported method type is provided.
		/// </exception>
		public static string GetMethodName(this MethodType methodType)
		{
			return methodType switch
			{
				MethodType.TelegramMessage => MethodNames.TelegramMessage,
				MethodType.WhatsAppMessage => MethodNames.WhatsAppMessage,
				MethodType.SmsOtp => MethodNames.SmsOtp,
				MethodType.WhatsAppOtp => MethodNames.WhatsAppOtp,
				_ => throw new ArgumentOutOfRangeException(nameof(methodType), methodType, message: null)
			};
		}

		/// <summary>
		/// Converts a string value to its corresponding <see cref="MethodType"/>.
		/// </summary>
		/// <param name="value">The string value to convert.</param>
		/// <returns>The corresponding method type.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Thrown when an invalid method name value is provided.
		/// </exception>
		public static MethodType GetMethodType(this string value)
		{
			return value switch
			{
				MethodNames.TelegramMessage => MethodType.TelegramMessage,
				MethodNames.WhatsAppMessage => MethodType.WhatsAppMessage,
				MethodNames.SmsOtp => MethodType.SmsOtp,
				MethodNames.WhatsAppOtp => MethodType.WhatsAppOtp,
				_ => throw new ArgumentOutOfRangeException(
					nameof(value),
					value,
					message: "Invalid method name value provided"
				)
			};
		}
	}
}