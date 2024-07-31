namespace Server.Domain.Entities;

public class Sensor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Device? Device { get; set; }
    public int DeviceId { get; set; }
    public ICollection<SensorValue> Messures { get; set; } = new List<SensorValue>();
    public string SensorValueTypeName { get; set; } = typeof(SensorValue).Name;
}