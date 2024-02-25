namespace VantageLibrary.Types; 
public class VantageLabel {
    public Guid Identifier { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public List<VantageParameter> Params { get; set; }
}
