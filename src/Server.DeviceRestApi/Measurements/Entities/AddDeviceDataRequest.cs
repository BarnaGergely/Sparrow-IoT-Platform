namespace Server.DeviceRestApi.Measurements.Entities;
public record AddDeviceDataRequest{
    public int DeviceId { get; init; }
    public DateTime? MeasurementTime { get; init; }
    public IEnumerable<MeasurementInRequest> Measurements { get; init; } = [];
}