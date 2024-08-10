namespace VSCSharp.Models.Results;

public record InitializationResult
{
	public List<Method> AvailableMethods { get; set; } = new();
}