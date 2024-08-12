using Server.Domain.Entities;
using DotNext;
using System.Text.Json;

namespace Server.Application.Measurements;

public class MeasurementsMapper(IMeasurementsService measurementsService)
{
    public Result<Measurement> Map(MeasurementRaw input)
    {
        // Determine the kind of the sensor
        Result<Sensor> kindResult = measurementsService.GetSensor(input.SensorId);
        if (!kindResult.IsSuccessful)
        {
            return new Result<Measurement>(kindResult.Error);
        }

        MeasurementKind kind = kindResult.Value.Kind;
        JsonElement valueElement = (JsonElement)input.Value;

        // Convert the value of the messurement to the appropriate type with switch-case
        double value = kind switch
        {

            MeasurementKind.Temperature => valueElement.GetDouble(),
            MeasurementKind.Boolean => valueElement.GetDouble(),
            MeasurementKind.Percentage => valueElement.GetDouble(),
            MeasurementKind.Integer => valueElement.GetDouble(),
            _ => throw new NotImplementedException()
        };

        return new Measurement
        {
            SensorId = input.SensorId,
            Kind = kind,
            Value = value,
        };
    }
}