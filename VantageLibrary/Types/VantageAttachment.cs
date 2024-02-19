namespace VantageLibrary.Types; 
public class VantageAttachment {
    public Guid Identifier { get; set; }
    public string Data { get; set; }
    public string Description { get; set; }
    public FileInfo File { get; set; }
    public string Name { get; set; }
}
