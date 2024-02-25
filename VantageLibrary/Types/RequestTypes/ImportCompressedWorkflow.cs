namespace VantageLibrary.Types.RequestTypes;

public class ImportCompressedWorkflow
{
    public bool AllowOverwrite { get; set; }
    public string CompressedWorkflow { get; set; }
    public Guid DestinationCategory { get; set; }
    public bool DuplicateVariables { get; set; }
}
