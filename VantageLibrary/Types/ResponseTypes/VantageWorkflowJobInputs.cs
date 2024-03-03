namespace VantageLibrary.Types; 
public class VantageWorkflowJobInputs {
    public List<VantageAttachment> Attachments { get; set; }
    public string JobName { get; set; }
    public List<VantageLabel> Labels { get; set; }
    public List<VantageMedia> Medias { get; set; }
    public int Priority { get; set; }
    public List<VantageVariable> Variables { get; set; }
}
