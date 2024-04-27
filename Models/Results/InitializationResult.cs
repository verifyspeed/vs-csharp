namespace VSCSharp.Models.Results;

public record InitializationResult
{
	public List<InitializationDataSet> Methods { get; set; } = new();
}