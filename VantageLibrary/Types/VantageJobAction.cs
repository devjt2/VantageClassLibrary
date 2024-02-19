namespace VantageLibrary.Types; 
public class VantageJobAction {
    public Guid Identifier { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public DateTime Started { get; set; }
    public int State { get; set; }
    public DateTime Updated { get; set; }
}
