using Application.Common.Entities;
using DotNext;

namespace Application.IotDevice.Measurements;

public interface IMeasurementsCommandHandler
{
    public Result<Nothing> AddMeasurements(AddMeasurementsCommand data);
}
