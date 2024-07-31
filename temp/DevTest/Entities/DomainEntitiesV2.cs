
// Json serialization is working, but EF core not works

// EF core error: Unable to create a 'DbContext' of type ''. The exception 'The property 'SensorValueV2.Value' could not be mapped because it is of type 'object', which is not a supported primitive type or a valid entity type. Either explicitly map this property, or ignore it using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728

namespace DevTest;

using System.Text.Json.Serialization;

public record DeviceV2
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<SensorV2> Sensors { get; set; }
}

public class SensorV2
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DeviceV2? DeviceV2 { get; set; }
    public int DeviceId { get; set; }
    public ICollection<SensorValueV2> Messures { get; set; } = new List<SensorValueV2>();
    public string SensorValueV2TypeName { get; set; } = typeof(SensorValueV2).Name;
}

[JsonDerivedType(typeof(SensorValueV2IntNumber), typeDiscriminator: "int")]
[JsonDerivedType(typeof(SensorValueV2FloatNumber), typeDiscriminator: "float")]
public record SensorValueV2
{
    public int Id { get; set; }
    public virtual object Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public SensorV2? SensorV2 { get; set; }
    public int SensorId { get; set; }
}

public record SensorValueV2IntNumber : SensorValueV2
{
    public int ValueTyped { get; set; }
    public override object Value { get => ValueTyped; set => ValueTyped = (int)value; }
}

public record SensorValueV2FloatNumber : SensorValueV2
{
    public float ValueTyped { get; set; }
    public override object Value { get => ValueTyped; set => ValueTyped = (float)value; }
}