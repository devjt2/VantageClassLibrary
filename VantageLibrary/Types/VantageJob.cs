namespace VantageLibrary.Types; 

public class VantageJob {
    public Guid Identifier { get; set; }
    public bool IsMonitor { get; set; }
    public string Name { get; set; }
    public DateTime Started { get; set; }
    public string Started_UTC { get; set; }
    public int State { get; set; }
    public DateTime Updated { get; set; }
    public string Updated_UTC { get; set; }
}
