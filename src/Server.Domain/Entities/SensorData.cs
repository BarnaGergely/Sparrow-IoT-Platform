using System.Runtime.Intrinsics.X86;

namespace Server.Domain.Entities;

public record SensorData<T>(Guid Id, DateTime Timestamp, T Value);
