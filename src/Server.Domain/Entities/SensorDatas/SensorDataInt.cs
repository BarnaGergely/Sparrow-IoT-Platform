namespace Server.Domain.Entities.SensorDataTypes;
public record SensorDataInt : ISensorData<int>
{
    public Guid Id { get; }
    public Guid SensorId { get; }
    public DateTime Timestamp { get; }
    public int Value { get; }

    public SensorDataInt(Guid id, Guid sensorId, DateTime timestamp, int value)
    {
        Id = id;
        SensorId = sensorId;
        Timestamp = timestamp;
        Value = value;
    }
    
}
