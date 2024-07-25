namespace Server.Domain.Entities.SensorDataTypes;
public interface ISensorData<T> 
{
    public Guid SensorId { get; }
    public DateTime Timestamp { get; }
    public T Value { get; }
}