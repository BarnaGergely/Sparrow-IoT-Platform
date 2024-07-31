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

using var context = new TestingContext();


//context.Add(deviceV3);

//context.SaveChanges();

// get device
DeviceV3 device = context.Devices.First();

SensorV3 sensor = context.Sensors.First();

Console.WriteLine($"Device: {device.Name}, {device.Id}");

Console.WriteLine(deviceV2.Sensors.First().Messures.First().Value.GetType().Name);

Console.WriteLine($"First data: {sensor.Messures.First().GetType().Name}");

Console.WriteLine("______________Program finished__________________");