using DotNext;
using Server.Domain.Entities;

namespace Server.Application.Messures;

public interface IMessureRepository
{
    Task<Result<SensorValue>> AddMessureAsync(SensorValue messure);
    // TODO: how to use Result as void?
    Task<Result<int>> AddMessuresAsync(IEnumerable<SensorValue> messures);
}
