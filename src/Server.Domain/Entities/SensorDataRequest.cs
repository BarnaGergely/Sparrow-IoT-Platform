public record SensorDataRequest(Guid DeviceId, DateTime Timestamp, SensorField[] Fields);