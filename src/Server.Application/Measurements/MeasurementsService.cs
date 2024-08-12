using DotNext;
using Server.Domain.Entities;

namespace Server.Application.Measurements;

public class MeasurementsService : IMeasurementsService
{
    private readonly IMeasurementsRepository _repository;
    public MeasurementsService(IMeasurementsRepository repository)
    {
        _repository = repository;
    }

    public Result<Nothing> AddMeasurements(IEnumerable<Measurement> measurements)
    {
        _repository.Measurements.AddRange(measurements);
        _repository.SaveChanges();
        return new Result<Nothing>();
    }

    public Result<bool> DeviceIdIsValid(int deviceId)
    {
        return _repository.Devices.Any(device => device.Id == deviceId);
    }

    public Result<Sensor> GetSensor(int sensorId)
    {
        return _repository.Sensors.FirstOrDefault(sensor => sensor.Id == sensorId)
            ?? new Result<Sensor>(new KeyNotFoundException($"Sensor {sensorId} not found"));
    }

    public Result<bool> IsSensorAssignedToDevice(int sensorId, int deviceId)
    {
        return _repository.Devices
            .Any(device => device.Id == deviceId && device.Sensors.Any(sensor => sensor.Id == sensorId));
    }

    public Result<bool> SensorIdIsValid(int sensorId)
    {
        return _repository.Sensors.Any(sensor => sensor.Id == sensorId);
    }
}
