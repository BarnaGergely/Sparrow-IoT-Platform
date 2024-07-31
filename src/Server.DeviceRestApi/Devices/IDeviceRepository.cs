using DotNext;
using Server.Domain.Entities;

namespace Server.DeviceRestApi;

public interface IDeviceRepository
{
    Task<Result<Device>> GetDeviceAsync(int id);
    Task<Result<bool>> DeviceExistsAsync(int id);

}
