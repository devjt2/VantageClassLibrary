using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VantageLibrary.Types;

namespace VantageLibrary.Utilities {
    public class Serialization {

        public static T Deserialize<T>(string inputJson)
        {
            if (inputJson == null)
            {
                throw new ArgumentNullException(nameof(inputJson));
            }
            return JsonSerializer.Deserialize<T>(inputJson);
        }
        public static string Serialize<T>(T inputObject)
        {
            if (inputObject == null)
            {
                throw new ArgumentNullException(nameof(inputObject));
            }
            return JsonSerializer.Serialize(inputObject);
        }
    }
}
