namespace VantageLibrary.Types; 
public class VantageVariable {
    public Guid Identifier { get; set; }
    public string DefaultValue { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string TypeCode { get; set; }
    public string Value { get; set; }
}
