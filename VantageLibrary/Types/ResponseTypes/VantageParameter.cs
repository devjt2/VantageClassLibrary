namespace VantageLibrary.Types; 
public class VantageParameter {
    public Guid Identifier { get; set; }
    public string Category { get; set; }
    public string DefaultValue { get; set; }
    public string Description { get; set; }
    public string Increment { get; set; }
    public string Maximum { get; set; }
    public string Minimum { get; set; }
    public string Name { get; set; }
    public List<string> Options { get; set; }
    public string TypeCode { get; set; }
    public string Value { get; set; }
}
