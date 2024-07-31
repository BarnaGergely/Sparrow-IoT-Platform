using DotNext;
using Server.Application.Devices.Sensors;
using Server.DeviceRestApi.Devices.Datas.Entities;
using Server.Domain.Entities;

namespace Server.DeviceRestApi;
/*
public class SensorValueConverter
{
    private ISensorRepository _sensorRepository { get; init; }
    public SensorValue ToGenerics(SensorValue sensorValue)
    {
        Result<Sensor> sensorValueTypeResult = _sensorRepository.GetSensorAsync(sensorValue.SensorId).Result;
        if (!sensorValueTypeResult.IsSuccessful)
        {
            throw new Exception("Sensor not found");
        }
        else
        {
            throw new NotSupportedException("Unsupported sensorValue type");
        }

        // TODO: Null checking, Exception handling
        // TODO: Refactor this to be dynamic
        switch (sensorValueType)
        {
            case Type t when t == typeof(SensorValue<int>):
                return new SensorValue<int> { Id = sensorValue.Id, ValueTyped = (int)sensorValue.Value, CreatedAt = sensorValue.CreatedAt, Sensor = sensorValue.Sensor, SensorId = sensorValue.SensorId };
            case Type t when t == typeof(SensorValue<float>):
                return new SensorValue<float> { Id = sensorValue.Id, ValueTyped = (float)sensorValue.Value, CreatedAt = sensorValue.CreatedAt, Sensor = sensorValue.Sensor, SensorId = sensorValue.SensorId };
            case Type t when t == typeof(SensorValue<string>):
                return new SensorValue<string> { Id = sensorValue.Id, ValueTyped = (string)sensorValue.Value, CreatedAt = sensorValue.CreatedAt, Sensor = sensorValue.Sensor, SensorId = sensorValue.SensorId };
            case Type t when t == typeof(SensorValue<bool>):
                return new SensorValue<bool> { Id = sensorValue.Id, ValueTyped = (bool)sensorValue.Value, CreatedAt = sensorValue.CreatedAt, Sensor = sensorValue.Sensor, SensorId = sensorValue.SensorId };
            default:
                throw new NotSupportedException("Unsupported sensorValue type");
        }
    }

    public SensorValue ToGenerics(SensorValueInRequest sensorValue)
    {
        Type sensorValueType = _sensorsRepository.GetSensorAsync(sensorValue.SensorId).Result.SensorValueType;

        switch (sensorValueType)
        {
            case Type t when t == typeof(SensorValue<int>):
                return new SensorValue<int> { ValueTyped = (int)sensorValue.Value };
            case Type t when t == typeof(SensorValue<float>):
                return new SensorValue<float> { ValueTyped = (float)sensorValue.Value };
            case Type t when t == typeof(SensorValue<string>):
                return new SensorValue<string> { ValueTyped = (string)sensorValue.Value };
            case Type t when t == typeof(SensorValue<bool>):
                return new SensorValue<bool> { ValueTyped = (bool)sensorValue.Value };
            default:
                throw new NotSupportedException("Unsupported sensorValue type");
        }
    }
}
*/