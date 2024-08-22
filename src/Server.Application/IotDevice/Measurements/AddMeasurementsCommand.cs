namespace Server.Application.IotDevice.Measurements;

public record class AddMeasurementsCommand
{
    public int DeviceId { get; init; }
    public DateTime? MeasurementTime { get; init; }
    public DateTime ReceptionTime { get; init; }
    public IEnumerable<MeasurementRaw> Measurements { get; init; } = [];
}

public record class MeasurementRaw
{
    public int SensorId { get; init; }
    public object Value { get; init; }
    public DateTime? CreatedAt { get; init; }
}
