namespace VantageLibrary.Types;

public class VantageServiceMetric
{
    public ServiceMetric Metric { get; set; }

    public class ServiceMetric
    {
        public bool AcceptingWork { get; set; }
        public long ActiveSessionCount { get; set; }
        public long AverageQueueLength { get; set; }
        public long AverageQueueWaitInSeconds { get; set; }
        public long CurrentResourceUsage { get; set; }
        public long FailedLicenseCount { get; set; }
        public long FailedSessionCount { get; set; }
        public long LightspeedFallbackCount { get; set; }
        public long QueuedSessionCount { get; set; }
        public long SendQueueSize { get; set; }
        public long ServiceUtilization { get; set; }
        public long SuccessfulSessionCount { get; set; }
        public long TargetResourceUsage { get; set; }
        public long TotalSessionCount { get; set; }
    }
}
