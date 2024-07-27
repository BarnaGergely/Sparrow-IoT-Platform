
namespace Server.Domain.Entities.ApiEntities;
public record SensorDataFloat(int DeviceId, float Value) : SensorData(DeviceId);