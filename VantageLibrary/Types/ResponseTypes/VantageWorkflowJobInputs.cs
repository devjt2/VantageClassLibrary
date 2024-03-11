namespace VantageLibrary.Types; 
public class VantageWorkflowJobInputs {
    public List<VantageAttachment> Attachments { get; set; } = new List<VantageAttachment>();
    public string JobName { get; set; } = "Default Job Name";
    public List<VantageLabel> Labels { get; set; } = new List<VantageLabel>();
    public List<VantageMedia> Medias { get; set; } = new List<VantageMedia>();
    public int Priority { get; set; } = 0;
    public List<VantageVariable> Variables { get; set; } = new List<VantageVariable> { };
}
