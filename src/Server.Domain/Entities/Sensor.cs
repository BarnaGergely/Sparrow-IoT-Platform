public record Sensor
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public Guid DeviceId { get; }
    public Guid SensorDataTypeId { get; }

    public Sensor(Guid id, string name, string description, Guid deviceId)
    {
        Id = id;
        Name = name;
        Description = description;
        DeviceId = deviceId;
    }
}