using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VantageLibrary.Types;

public class VantageMachine
{
    public Guid Identifier { get; set; }
    public string Name { get; set; }
    public long Processors { get; set; }
    public int MachineType { get; set; }
}
