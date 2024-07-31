using DotNext;
using Server.Domain.Entities;

namespace Server.Application.Devices.Sensors;

public interface ISensorRepository
{
    Task<Result<Sensor>> GetSensorAsync(int id);
}
