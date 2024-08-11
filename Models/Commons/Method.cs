using System.Text.Json.Serialization;

namespace VSCSharp.Models.Commons
{
	public record Method
	{
		[JsonPropertyName("methodName")]
		public string MethodName { get; set; } = null!;

		[JsonPropertyName("displayName")]
		public string DisplayName { get; set; } = null!;
	}
}
