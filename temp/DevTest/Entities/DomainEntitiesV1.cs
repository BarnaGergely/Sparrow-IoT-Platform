
// Problem: Json serialization is not working besause it uses generics and EF core not works because general object property

using System.Text.Json.Serialization;
namespace DevTest;
public record DeviceV1
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<SensorV1> Sensors { get; set; }
}

public class SensorV1
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DeviceV1? Device { get; set; }
    public int DeviceId { get; set; }
    public ICollection<SensorValueV1> Messures { get; set; } = new List<SensorValueV1>();
    public string SensorValueTypeName { get; set; } = typeof(SensorValueV1).Name;
}

// TODO: Null checking
// TODO: This might be an abstract class or interface
public class SensorValueV1
{
    [JsonIgnore]
    public int Id { get; set; }
    // TODO: This might be an dynamic type: https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/interop/using-type-dynamic
    public virtual object Value { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }
    [JsonIgnore]
    public SensorV1? Sensor { get; set; }
    public int SensorId { get; set; }
}

public class SensorValue<T> : SensorValueV1
{
    [JsonIgnore]
    public T ValueTyped { get; set; }
    public override object Value { get => ValueTyped; set => ValueTyped = (T)value; }
}