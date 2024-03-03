namespace VantageLibrary.Types; 
public class VantageBinder {
    public Guid Identifier { get; set; }
    public List<VantageBinderContent> Content { get; set; } = new List<VantageBinderContent>();
    public string Created_UTC { get; set; }
    public string Name { get; set; }
}
