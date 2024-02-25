namespace VantageLibrary.Types;

public class VantageExportWorkflow
{
    /// <summary>
    /// This needs to be a path (as Vantage sees it) that Vantage can use to export the workflow.
    /// </summary>
    public string BasePathForExport { get; set; }
    public string WorkflowIdentifier { get; set; }
}
