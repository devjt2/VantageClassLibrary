using System.Text.Json.Serialization;

namespace VantageLibrary.Types; 
public class VantageMedia {
    public Guid Identifier { get; set; }
    public string Data { get; set; }
    public string Description { get; set; }
    [JsonConverter(typeof(Utilities.FileInfoListConverter))]
    public List<FileInfo> Files { get; set; } = new List<FileInfo>();
    public string Name { get; set; }
}
