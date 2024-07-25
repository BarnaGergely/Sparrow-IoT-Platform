namespace Server.Domain.Entities;
public record SensorDataType
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public Type DataType { get; }
}