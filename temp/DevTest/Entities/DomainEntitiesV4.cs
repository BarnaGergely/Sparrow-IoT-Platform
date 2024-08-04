
// Json serialization is working, but EF core not works

// EF core error: Unable to create a 'DbContext' of type ''. The exception 'The property 'SensorValueV4.Value' could not be mapped because it is of type 'object', which is not a supported primitive type or a valid entity type. Either explicitly map this property, or ignore it using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728

namespace DevTest;

using System.Text.Json.Serialization;

public record DeviceV4
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<SensorV4> Sensors { get; set; }
}

public class SensorV4
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DeviceV4? DeviceV4 { get; set; }
    public int DeviceV4Id { get; set; }
}
public class SensorV4<TMessure> : SensorV4 where TMessure: IMessureV4
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DeviceV4? DeviceV4 { get; set; }
    public int DeviceV4Id { get; set; }
    public ICollection<TMessure> Messures { get; set; } = new List<TMessure>();
}

[JsonDerivedType(typeof(MessureTemperature), typeDiscriminator: "temperature")]
[JsonDerivedType(typeof(MessurePercentage), typeDiscriminator: "percentage")]
public interface IMessureV4
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public SensorV4<IMessureV4> SensorV4 { get; set; }
    public int SensorV4Id { get; set; }
}

public record MessureTemperature : IMessureV4
{
    public float Value { get; set; }
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public SensorV4<IMessureV4> SensorV4 { get; set; }
    public int SensorV4Id { get; set; }
}

public record MessurePercentage : IMessureV4
{
    public int Value { get; set; }
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public SensorV4<IMessureV4> SensorV4 { get; set; }
    public int SensorV4Id { get; set; }
}