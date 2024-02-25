using System.Text.Json.Serialization;

namespace VantageLibrary.Types;

public class VantageExportedWorkflow
{
    [JsonConverter(typeof(Utilities.FileInfoConverter))]
    public FileInfo PathToExportedFile { get; set; }
}
