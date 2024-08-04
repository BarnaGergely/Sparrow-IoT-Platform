using DevTest;

Console.WriteLine("______________Program started__________________");

var deviceV3 = new DeviceV3
{
    Name = "Device 1",
    Description = "Device 1 description",
    Sensors = new List<SensorV3>
    {
        new SensorV3
        {
            Name = "Sensor 1",
            Description = "Sensor 1 description",
            Messures = new List<SensorValueV3>
            {
                new SensorValueV3IntNumber
                {
                    Value = 1
                },
                new SensorValueV3IntNumber
                {
                    Value = 64
                }
            }
        },
        new SensorV3
        {
            Name = "Sensor 2",
            Description = "Sensor 2 description",
            Messures = new List<SensorValueV3>
            {
                new SensorValueV3FloatNumber
                {
                    Value = 1.1f
                },
                new SensorValueV3FloatNumber
                {
                    Value = 64.4f
                }
            }
        }
    }
};

var deviceV2 = new DeviceV2
{
    Name = "Device 2",
    Description = "Device 2 description",
    Sensors = new List<SensorV2>
    {
        new SensorV2
        {
            Name = "Sensor 1",
            Description = "Sensor 1 description",
            Messures = new List<SensorValueV2>
            {
                new SensorValueV2IntNumber
                {
                    Value = 1
                },
                new SensorValueV2IntNumber
                {
                    Value = 64
                }
            }
        },
        new SensorV2
        {
            Name = "Sensor 2",
            Description = "Sensor 2 description",
            Messures = new List<SensorValueV2>
            {
                new SensorValueV2FloatNumber
                {
                    Value = 1.1f
                },
                new SensorValueV2FloatNumber
                {
                    Value = 64.4f
                }
            }
        }
    }
};

var deviceV5 = new DeviceV5
{
    Id = 1,
    Name = "Device 3",
    Description = "Device 3 description",
    Sensors = new List<SensorV5>
    {
        new SensorV5
        {
            Id = 1,
            DeviceV5Id = 1,
            Name = "Sensor 1",
            Description = "Sensor 1 description",
            Measures = new List<MeasureV5>
            {
                new MeasureTemperatureV5
                {
                    SensorV5Id = 1,
                    Value = 1.1f
                },
                new MeasureTemperatureV5
                {
                    SensorV5Id = 1,
                    Value = 64.4f
                }
            }
        },
        new SensorV5
        {
            Id = 2,
            DeviceV5Id = 1,
            Name = "Sensor 2",
            Description = "Sensor 2 description",
            Measures = new List<MeasureV5>
            {
                new MeasurePercentageV5
                {
                    SensorV5Id = 2,
                    Value = 1
                },
                new MeasurePercentageV5
                {
                    SensorV5Id = 2,
                    Value = 64
                }
            }
        }
    }
};

using var context = new TestingContext();

//context.Add(deviceV5);
//context.SaveChanges();

// get device
DeviceV5 device = context.Devices.First();

MeasureV5 measure = context.Sensors.FirstOrDefault().Measures.FirstOrDefault();

if (measure is null)
{
    Console.WriteLine("Failed to get measure");
    return;
} else if (measure is MeasureTemperatureV5 measureTemperature)
{
    Console.WriteLine($"Temperature measure: {measureTemperature.Value}");
}
else if (measure is MeasurePercentageV5 measurePercentage)
{
    Console.WriteLine($"Percentage measure: {measurePercentage.Value}");
} else
{
    Console.WriteLine("Unknown measure type");
}

Console.WriteLine("______________Program finished__________________");