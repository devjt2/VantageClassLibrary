namespace VantageLibrary.Types;

public class VantageStore
{
    public Guid Identifier { get; set; }
    public List<string> Aliases { get; set; }
    public long AvailableSpace { get; set; }
    public string Location { get; set; }
    public string Name { get; set; }
    public bool Offline { get; set; }
    public int StorageMode { get; set; }
    public long TotalSpace { get; set; }
}
