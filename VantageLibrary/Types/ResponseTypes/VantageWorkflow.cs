using VantageLibrary.Enums;

namespace VantageLibrary.Types.ResponseTypes
{
    public class VantageWorkflow
    {
        public Guid Identifier { get; set; }
        public string Description { get; set; }
        public int ExpirationInHours { get; set; }
        public string Name { get; set; }
        public WorkflowStateEnum State { get; set; }
        public DateTime UTC_ModifiedTime { get; set; }
    }
}
