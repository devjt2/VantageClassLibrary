namespace VantageLibrary.Types.RequestTypes;

public class SynchronizeWorkflowFromFile
{
    public Guid DestinationCategory { get; set; }
    public string Path { get; set; }
}
