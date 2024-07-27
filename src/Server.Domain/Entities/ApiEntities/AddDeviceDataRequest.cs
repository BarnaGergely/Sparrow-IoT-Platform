namespace Server.Domain.Entities.ApiEntities;
public record AddDeviceDataRequest(int DeviceId, IEnumerable<SensorData> SensorDatas);