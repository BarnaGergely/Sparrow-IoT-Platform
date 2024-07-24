using System.Runtime.Intrinsics.X86;

namespace Server.Domain.Entities;

public record SensorData(Guid Id, Guid DeviceId, Guid SensorId, DateTime Timestamp, dynamic Data);
