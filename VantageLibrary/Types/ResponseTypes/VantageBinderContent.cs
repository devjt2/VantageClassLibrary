namespace VantageLibrary.Types; 
public class VantageBinderContent {
    public Guid ContentIdentifier { get; set; }
    public DateTime Created { get; set; }
    public string? Created_UTC { get; set; }
    public string? Name { get; set; }
    public DateTime Updated { get; set; }
    public string? Updated_UTC { get; set; }
}
