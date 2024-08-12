using Server.Application.Measurements;

namespace Server.DeviceRestApi.Measurements.Entities;

public class MeasurementInRequest
{
    public required int SensorId { get; set; }
    public required object Value { get; set; }
    public DateTime? CreatedAt { get; set; }
}
