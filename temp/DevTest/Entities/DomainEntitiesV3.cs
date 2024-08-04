
// Json serialization is working, but EF core not works

// EF core error: Unable to create a 'DbContext' of type ''. The exception 'The property 'SensorValueV3.Value' could not be mapped because it is of type 'object', which is not a supported primitive type or a valid entity type. Either explicitly map this property, or ignore it using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728

namespace DevTest;

using System.Text.Json.Serialization;

public record DeviceV3
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<SensorV3> Sensors { get; set; }
}

public record SensorV3
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DeviceV3? DeviceV3 { get; set; }
    public int DeviceId { get; set; }
    public ICollection<SensorValueV3> Messures { get; set; } = new List<SensorValueV3>();
    public string SensorValueV2TypeName { get; set; } = typeof(SensorValueV3).Name;
}

[JsonDerivedType(typeof(SensorValueV3IntNumber), typeDiscriminator: "int")]
[JsonDerivedType(typeof(SensorValueV3FloatNumber), typeDiscriminator: "float")]
public record SensorValueV3
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public SensorV3? SensorV3 { get; set; }
    public int SensorId { get; set; }
}

public record SensorValueV3IntNumber : SensorValueV3
{
    public int Value { get; set; }
}

public record SensorValueV3FloatNumber : SensorValueV3
{
    public float Value { get; set; }
}