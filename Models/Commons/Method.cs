using System.Text.Json.Serialization;

namespace VSCSharp.Models.Commons
{
	/// <summary>
	/// Represents a verification method with its technical name and user-friendly display name.
	/// </summary>
	public record Method
	{
		/// <summary>
		/// Gets or sets the technical name of the verification method.
		/// This is used internally, for example, "TelegramMessage" or "WhatsAppMessage".
		/// </summary>
		[JsonPropertyName("methodName")]
		public string MethodName { get; init; } = null!;

		/// <summary>
		/// Gets or sets the user-friendly display name of the verification method.
		/// This is the name shown to users, for example, "Telegram" or "WhatsApp".
		/// </summary>
		[JsonPropertyName("displayName")]
		public string DisplayName { get; init; } = null!;
	}
}
