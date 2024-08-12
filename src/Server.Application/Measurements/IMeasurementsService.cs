namespace Server.Application.Measurements;
using DotNext;
using Server.Domain.Entities;

public interface IMeasurementsService
{
    Result<bool> DeviceIdIsValid(int deviceId);
    Result<bool> SensorIdIsValid(int sensorId);
    Result<bool> IsSensorAssignedToDevice(int sensorId, int deviceId);
    Result<Sensor> GetSensor(int sensorId);
    Result<Nothing> AddMeasurements(IEnumerable<Measurement> measurements);
}