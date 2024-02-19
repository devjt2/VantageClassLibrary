namespace VantageLibrary.Types; 
public class VantageCategory {
    public Guid Identifier { get; set; }
    public string Name { get; set; }
    public List<VantageWorkflow> Workflows { get; set; }
}
