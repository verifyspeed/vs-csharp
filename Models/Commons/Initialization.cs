namespace VSCSharp.Models.Commons;

public record Initialization
{
	public List<Method> AvailableMethods { get; set; } = new();
}