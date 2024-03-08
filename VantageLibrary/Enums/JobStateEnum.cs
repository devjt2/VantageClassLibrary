using System.Text.Json.Serialization;

namespace VantageLibrary.Enums;

public enum JobStateEnum
{
    [JsonPropertyName("In Process")]
    In_Process = 0,
    Failed = 4,
    Complete = 5,
    Waiting = 6,
    [JsonPropertyName("Stopped by User")]
    Stopped_by_User = 7,
    [JsonPropertyName("Waiting to Retry")]
    Waiting_to_Retry = 8,
    [JsonPropertyName("Queued for Submission")]
    Queued_for_Submission = 10,
    [JsonPropertyName("No Such Job")]
    No_Such_Job = 11
}
