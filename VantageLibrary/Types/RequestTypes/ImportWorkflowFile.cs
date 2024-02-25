namespace VantageLibrary.Types.RequestTypes;

public class ImportWorkflowFromFile
{
    public bool AllowOverwrite { get; set; }
    public Guid DestinationCategory { get; set; }
    public bool DuplicateVariables { get; set; }
    public string Path { get; set; }
}
