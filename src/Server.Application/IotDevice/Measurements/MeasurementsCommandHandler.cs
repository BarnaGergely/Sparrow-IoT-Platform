using DotNext;
using Server.Application.Common.Entities;
using Server.Domain.Entities;


namespace Server.Application.IotDevice.Measurements;

public class MeasurementsCommandHandler : IMeasurementsCommandHandler
{
    private readonly IMeasurementsService _service;
    private readonly IMeasurementsMapper _mapper;
    public MeasurementsCommandHandler(IMeasurementsService service, IMeasurementsMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    public Result<Nothing> AddMeasurements(AddMeasurementsCommand data)
    {
        Result<bool> deviceResult = _service.DeviceIdIsValid(data.DeviceId);
        if (!deviceResult.IsSuccessful)
            return new Result<Nothing>(deviceResult.Error);
        if (!deviceResult.Value)
            return new Result<Nothing>(new KeyNotFoundException($"Device {data.DeviceId} not found"));

        List<Measurement> measurements = [];

        // Convert Measurement to Measurement<T> and store in the Measurements list
        foreach (var measurement in data.Measurements)
        {
            // Validate if sensorId is valid
            Result<bool> sensorResult = _service.SensorIdIsValid(measurement.SensorId);
            if (!sensorResult.IsSuccessful)
                return new Result<Nothing>(sensorResult.Error);
            if (!sensorResult.Value)
                return new Result<Nothing>(new KeyNotFoundException($"Sensor {measurement.SensorId} not found"));

            // Validate if sensor is assigned to the device
            Result<bool> sensorAssignmentResult = _service.IsSensorAssignedToDevice(measurement.SensorId, data.DeviceId);
            if (!sensorAssignmentResult.IsSuccessful)
                return new Result<Nothing>(sensorAssignmentResult.Error);
            if (!sensorAssignmentResult.Value)
                return new Result<Nothing>(new KeyNotFoundException($"Sensor {measurement.SensorId} is not assigned to device {data.DeviceId}"));

            Result<Measurement> convertedResult = _mapper.Map(measurement);
            if (!convertedResult.IsSuccessful)
                return new Result<Nothing>(convertedResult.Error);

            Measurement converted = convertedResult.Value;

            converted.ReceptionTime = data.ReceptionTime;
            converted.MeasurementTime = data.MeasurementTime;

            measurements.Add(converted);
        }

        // Save sensor values
        var result = _service.AddMeasurements(measurements);
        if (!result.IsSuccessful)
            // TODO: Change it to internal server error
            return new Result<Nothing>(result.Error);

        return new Result<Nothing>();
    }
}