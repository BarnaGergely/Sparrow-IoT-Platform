
namespace Server.Domain.Entities.ApiEntities;

public record SensorDataInt(int DeviceId, int Value) : SensorData(DeviceId);
