using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Demo.SimplifyingApi.Data.Model;

namespace Demo.SimplifyingApi.Data.Convertors
{
    public class UserNameJsonConverter : JsonConverter<UserName>
    {
        public override UserName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return UserName.Parse(value: reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, UserName value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value: value.ToJson());
        }
    }
}