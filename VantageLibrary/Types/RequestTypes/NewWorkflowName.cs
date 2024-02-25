using System.Text.Json.Serialization;

namespace VantageLibrary.Types.RequestTypes;

public class NewWorkflowName
{
    [JsonPropertyName("NewWorkflowName")]
    public string Name { get; set; }
}
