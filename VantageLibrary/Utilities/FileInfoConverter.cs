using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VantageLibrary.Utilities
{
    public class FileInfoConverter : JsonConverter<FileInfo>
    {
        public override FileInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string filePath = JsonSerializer.Deserialize<string>(ref reader, options);
                return new FileInfo(filePath);
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, FileInfo value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            string filePath = value.FullName;
            JsonSerializer.Serialize(writer, filePath, options);
        }
    }
}