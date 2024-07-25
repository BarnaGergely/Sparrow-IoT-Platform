using Server.Domain.Entities.SensorDataTypes;

namespace Server.Domain.Entities;
public record AddDeviceDataRequest {
    public Guid DeviceId { get; init; }
    public DateTime Timestamp { get; init; }
    public required ISensorData<object>[] SensorDatas { get; init; }
}