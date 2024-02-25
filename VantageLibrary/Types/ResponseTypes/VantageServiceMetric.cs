namespace VantageLibrary.Types;

public class VantageServiceMetric
{
    public ServiceMetric Metric { get; set; }

    public class ServiceMetric
    {
        public bool AcceptingWork { get; set; }
        public int ActiveSessionCount { get; set; }
        public int AverageQueueLength { get; set; }
        public int AverageQueueWaitInSeconds { get; set; }
        public int CurrentResourceUsage { get; set; }
        public int FailedLicenseCount { get; set; }
        public int FailedSessionCount { get; set; }
        public int LightspeedFallbackCount { get; set; }
        public int QueuedSessionCount { get; set; }
        public int SendQueueSize { get; set; }
        public int ServiceUtilization { get; set; }
        public int SuccessfulSessionCount { get; set; }
        public int TargetResourceUsage { get; set; }
        public int TotalSessionCount { get; set; }
    }
}
