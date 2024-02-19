namespace VantageLibrary.Types;

public class VantageJobInput
{
    public required string? JobName { get; set; }
    public int Priority { get; set; }
    public List<VantageAttachment> Attachments { get; set; } = new List<VantageAttachment>();
    public List<VantageLabel> Labels { get; set; } = new List<VantageLabel>();
    public List<VantageMedia> Medias { get; set; } = new List<VantageMedia>();
}
