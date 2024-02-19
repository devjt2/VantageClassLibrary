using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VantageLibrary.Types;

namespace VantageLibrary
{
    public class DomainClient : IDisposable
    {
        public VantageFunctions Functions;
        public DomainClient(Uri baseAddress)
        {
            Functions = new VantageFunctions(baseAddress);
        }
        public void Dispose()
        {
            Functions.Dispose();
        }
    }
}

