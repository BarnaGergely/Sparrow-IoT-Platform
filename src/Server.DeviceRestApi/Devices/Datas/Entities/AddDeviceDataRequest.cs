namespace Server.DeviceRestApi.Devices.Datas.Entities;
public record AddDeviceDataRequest{
    public int DeviceId { get; init; }
    public DateTime? CreatedAt { get; init; }
    public IEnumerable<SensorValueInRequest> SensorValues { get; init; } = [];
}