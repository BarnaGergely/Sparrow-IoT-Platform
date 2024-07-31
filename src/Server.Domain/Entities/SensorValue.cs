using System.Text.Json.Serialization;

namespace Server.Domain.Entities;


// TODO: Null checking
// TODO: This might be an abstract class or interface
public class SensorValue
{
    [JsonIgnore]
    public int Id { get; set; }
    // TODO: This might be an dynamic type: https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/interop/using-type-dynamic
    public virtual object Value { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }
    [JsonIgnore]
    public Sensor? Sensor { get; set; }
    public int SensorId { get; set; }
}

public class SensorValue<T> : SensorValue
{
    [JsonIgnore]
    public T ValueTyped { get; set; }
    public override object Value { get => ValueTyped; set => ValueTyped = (T)value; }
    public static IEnumerable<SensorValue<T>> ConvertToGeneric(IEnumerable<SensorValue> values)
    {
        return new List<SensorValue<T>>(values.Select(v => new SensorValue<T>
        {
            ValueTyped = (T)v.Value,
            CreatedAt = v.CreatedAt
        }));
    }
}

/*
[JsonDerivedType(typeof(SensorValueIntNumber), typeDiscriminator: "int")]
[JsonDerivedType(typeof(SensorValueFloatNumber), typeDiscriminator: "float")]
public record SensorValue
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Sensor? Sensor { get; set; }
    public int SensorId { get; set; }
}

public record SensorValueIntNumber : SensorValue
{
    public int Value {get; set;}
}

public record SensorValueFloatNumber : SensorValue
{
    public float Value {get; set;}
}
*/