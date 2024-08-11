using System.Text.Json.Serialization;

namespace VSCSharp.Models.Commons;

public record Initialization
{
	[JsonPropertyName("availableMethods")]
	public List<Method> AvailableMethods { get; set; } = new();
}