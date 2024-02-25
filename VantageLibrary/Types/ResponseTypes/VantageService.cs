namespace VantageLibrary.Types;

public class VantageService
{
    public Guid Identifier { get; set; }
    public Guid Machine { get; set; }
    public int MachineType { get; set; }
    public Guid ServiceKind { get; set; }
    public string ServiceTypeName { get; set; }
    public int State { get; set; }
}
