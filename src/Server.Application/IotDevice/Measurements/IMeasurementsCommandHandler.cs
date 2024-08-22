using DotNext;
using Server.Application.Common.Entities;

namespace Server.Application.IotDevice.Measurements;

public interface IMeasurementsCommandHandler
{
    public Result<Nothing> AddMeasurements(AddMeasurementsCommand data);
}
