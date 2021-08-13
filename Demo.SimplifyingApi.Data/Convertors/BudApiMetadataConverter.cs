using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Demo.SimplifyingApi.Data.Model;

namespace Demo.SimplifyingApi.Data.Convertors
{
    public class BudApiMetadataConverter : JsonConverter<BudApiMetadata>
    {
        public override BudApiMetadata Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotSupportedException(message: "BudApiMetadata cannot be parsed.");
        }

        public override void Write(Utf8JsonWriter writer, BudApiMetadata value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value: value.ToJson());
        }
    }
}