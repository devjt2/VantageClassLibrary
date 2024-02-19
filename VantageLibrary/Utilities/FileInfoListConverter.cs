using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VantageLibrary.Utilities
{
    public class FileInfoListConverter : JsonConverter<List<FileInfo>>
    {
        public override List<FileInfo> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                List<string> filePaths = JsonSerializer.Deserialize<List<string>>(ref reader, options);
                return filePaths?.ConvertAll(filePath => new FileInfo(filePath));
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, List<FileInfo> value, JsonSerializerOptions options)
        {

            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            string[] filePaths = value.ConvertAll(fileInfo => fileInfo.FullName).ToArray();
            JsonSerializer.Serialize(writer, filePaths, options);
        }
    }
}
