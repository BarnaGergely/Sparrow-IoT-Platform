namespace Server.DeviceRestApi.Devices.Datas.Entities;

public class SensorValueInRequest
{
    public required int SensorId { get; set; }
    public required object Value { get; set; }
    public DateTime? CreatedAt { get; set; }
}
