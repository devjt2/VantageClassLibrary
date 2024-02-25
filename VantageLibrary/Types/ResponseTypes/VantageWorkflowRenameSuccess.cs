using System.Text.Json.Serialization;

namespace VantageLibrary.Types.ResponseTypes;

public class VantageWorkflowRenameSuccess
{
    [JsonPropertyName("RenameSuccessful")]
    public bool Success { get; set; }
}
