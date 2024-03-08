using VantageLibrary.Enums;
namespace VantageLibrary.Types;


public class VantageJob {
    public Guid Identifier { get; set; }
    public bool IsMonitor { get; set; }
    public string Name { get; set; }
    public string Started { get; set; }
    public string Started_UTC { get; set; }
    public JobStateEnum State { get; set; }
    public string Updated { get; set; }
    public string Updated_UTC { get; set; }
}
