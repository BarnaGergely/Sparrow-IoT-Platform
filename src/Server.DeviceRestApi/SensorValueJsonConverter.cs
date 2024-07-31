using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Domain.Entities;

namespace Server.DeviceRestApi;
/*
// TODO: Not In Use - This is a custom JSON converter for SensorValue, but not working, other solutions are used
public class SensorValueJsonConverter : JsonConverter<SensorValue>
{
    public override SensorValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            JsonElement root = doc.RootElement;

            // Determine the type of the derived class
            if (root.TryGetProperty("Type", out JsonElement valueTypedElement))
            {
                Type valueType = valueTypedElement.ValueKind switch
                {
                    JsonValueKind.Number => typeof(SensorValue<int>),
                    JsonValueKind.String => typeof(SensorValue<string>),
                    JsonValueKind.True or JsonValueKind.False => typeof(SensorValue<bool>),
                    _ => throw new NotSupportedException("Unsupported type")
                };

                return (SensorValue)JsonSerializer.Deserialize(root.GetRawText(), valueType, options);
            }

            throw new JsonException("Invalid JSON for SensorValue");
        }
    }

    public override void Write(Utf8JsonWriter writer, SensorValue value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
    }
}
*/