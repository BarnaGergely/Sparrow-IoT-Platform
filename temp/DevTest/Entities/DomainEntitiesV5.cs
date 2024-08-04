
// Json serialization is working, but EF core not works

// EF core error: Unable to create a 'DbContext' of type ''. The exception 'The property 'SensorValueV4.Value' could not be mapped because it is of type 'object', which is not a supported primitive type or a valid entity type. Either explicitly map this property, or ignore it using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728

namespace DevTest;

public record DeviceV5
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<SensorV5> Sensors { get; set; }
}

public class SensorV5
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DeviceV5? DeviceV5 { get; set; }
    public int DeviceV5Id { get; set; }
    public ICollection<MeasureV5> Measures { get; set; } = new List<MeasureV5>();
}

public interface IMeasureV5
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public SensorV5 SensorV5 { get; set; }
    public int SensorV5Id { get; set; }
}

public interface IMeasureIntV5 : IMeasureV5
{
    public int Value { get; set; }
}

public interface IMeasureFloatV5 : IMeasureV5
{
    public float Value { get; set; }
}

public record MeasureV5 : IMeasureV5
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public SensorV5 SensorV5 { get; set; }
    public int SensorV5Id { get; set; }
}

public record MeasureTemperatureV5 : MeasureV5, IMeasureFloatV5
{
    public float Value { get; set; }
}

public record MeasurePercentageV5 : MeasureV5, IMeasureIntV5
{
    public int Value { get; set; }
}