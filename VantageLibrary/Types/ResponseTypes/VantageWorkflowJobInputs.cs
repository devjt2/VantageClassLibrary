using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VantageLibrary.Types.VantageContentEntries;

namespace VantageLibrary.Types; 
public class VantageWorkflowJobInputs {
    public List<VantageAttachment> Attachments { get; set; }
    public string JobName { get; set; }
    public List<VantageLabel> Labels { get; set; }
    public List<VantageMedia> Medias { get; set; }
    public long Priority { get; set; }
    public List<VantageVariable> Variables { get; set; }
}
