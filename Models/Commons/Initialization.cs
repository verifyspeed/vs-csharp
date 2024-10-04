using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VSCSharp.Models.Commons
{
	/// <summary>
	/// Represents the initialization response which contains the available verification methods.
	/// </summary>
	public record Initialization
	{
		/// <summary>
		/// Gets the list of available methods for verification.
		/// Each method represents a possible way to verify the user, such as Telegram, WhatsApp, or SMS.
		/// </summary>
		[JsonPropertyName("availableMethods")]
		public List<Method> AvailableMethods { get; init; } = new();
	}
}